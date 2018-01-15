class TreeManager {
    constructor (tree) {
        this._src = tree
        this.tree = flattenTree(cloneDeep(tree))
        this.tree.forEach(node => { this.setInitialCheckState(node) })
        this.searchMaps = new Map()
    }

    getNodeById (id) {
        return this.tree.get(id)
    }

    getMatches (searchTerm) {
        if (this.searchMaps.has(searchTerm)) {
            return this.searchMaps.get(searchTerm)
        }

        let proximity = -1
        let closestMatch = searchTerm
        this.searchMaps.forEach((m, key) => {
            if (searchTerm.startsWith(key) && key.length > proximity) {
                proximity = key.length
                closestMatch = key
            }
        })

        const matches = []

        if (closestMatch !== searchTerm) {
            const superMatches = this.searchMaps.get(closestMatch)
            superMatches.forEach(key => {
                const node = this.getNodeById(key)
                if (node.label.toLowerCase().indexOf(searchTerm) >= 0) {
                    matches.push(node._id)
                }
            })
        } else {
            this.tree.forEach(node => {
                if (node.label.toLowerCase().indexOf(searchTerm) >= 0) {
                    matches.push(node._id)
                }
            })
        }

        this.searchMaps.set(searchTerm, matches)
        return matches
    }

    filterTree (searchTerm) {
        const matches = this.getMatches(searchTerm)

        this.tree.forEach(node => {
            node.hide = true
        })

        matches.forEach(m => {
            const node = this.getNodeById(m)
            node.hide = false
        })

        const allNodesHidden = matches.length === 0
        return { allNodesHidden, tree: this.tree }
    }

    restoreNodes () {
        this.tree.forEach(node => {
            node.hide = false
        })

        return this.tree
    }

    /**
    * If the node didn't specify anything on its own
    * figure out the initial state based on parent selections
    * @param {object} node [description]
    */
    setInitialCheckState (node) {
        if (node.checked === undefined) node.checked = this.getNodeCheckedState(node)
    }

    /**
     * Figure out the check state based on parent selections.
     * @param  {[type]} node    [description]
     * @param  {[type]} tree    [description]
     * @return {[type]}         [description]
     */
    getNodeCheckedState (node) {
        let parentCheckState = false
        let parent = node._parent
        while (parent && !parentCheckState) {
            const parentNode = this.getNodeById(parent)
            parentCheckState = parentNode.checked || false
            parent = parentNode._parent
        }

        return parentCheckState
    }

    setNodeCheckedState (id, checked) {
        const node = this.getNodeById(id)
        node.checked = checked
        this.toggleChildren(id, checked)

        if (!checked) {
            this.unCheckParents(node)
        }
    }

    /**
     * Walks up the tree unchecking parent nodes
     * @param  {[type]} node [description]
     * @return {[type]}      [description]
     */
    unCheckParents (node) {
        let parent = node._parent
        while (parent) {
            let next = this.getNodeById(parent)
            next.checked = false
            parent = next._parent
        }
    }

    toggleChildren (id, state) {
        const node = this.getNodeById(id)
        node.checked = state
        if (!isEmpty(node._children)) {
            node._children.forEach(id => this.toggleChildren(id, state))
        }
    }

    toggleNodeExpandState (id) {
        const node = this.getNodeById(id)
        node.expanded = !node.expanded
        if (!node.expanded) this.collapseChildren(node)
        return this.tree
    }

    collapseChildren (node) {
        node.expanded = false
        if (!isEmpty(node._children)) {
            node._children.forEach(c => this.collapseChildren(this.getNodeById(c)))
        }
    }

    getTags () {
        const tags = []
        const visited = {}
        const markSubTreeVisited = (node) => {
            visited[node._id] = true
            if (!isEmpty(node._children)) node._children.forEach(c => markSubTreeVisited(this.getNodeById(c)))
        }

        this.tree.forEach((node, key) => {
            if (visited[key]) return

            if (node.checked) {
                // Parent node, so no need to walk children
                tags.push(node)
                markSubTreeVisited(node)
            } else {
                visited[key] = true
            }
        })
        return tags
    }
}

var DropdownTreeSelect = function (_Component) {
  _inherits(DropdownTreeSelect, _Component);

  function DropdownTreeSelect(props) {
    _classCallCheck(this, DropdownTreeSelect);

    var _this = _possibleConstructorReturn(this, (DropdownTreeSelect.__proto__ || Object.getPrototypeOf(DropdownTreeSelect)).call(this, props));

    _this.resetSearch = function () {
      // restore the tree to its pre-search state
      _this.setState({ tree: _this.treeManager.restoreNodes(), searchModeOn: false, allNodesHidden: false });
      // clear the search criteria and avoid react controlled/uncontrolled warning
      _this.searchInput.value = '';
    };

    _this.onAction = function (actionId, nodeId) {
      typeof _this.props.onAction === 'function' && _this.props.onAction(actionId, _this.treeManager.getNodeById(nodeId));
    };

    _this.state = { dropdownActive: _this.props.showDropdown || false, searchModeOn: false };

    _this.onInputChange = _this.onInputChange.bind(_this);
    _this.onDrowdownHide = _this.onDrowdownHide.bind(_this);
    _this.onCheckboxChange = _this.onCheckboxChange.bind(_this);
    _this.notifyChange = _this.notifyChange.bind(_this);
    _this.onTagRemove = _this.onTagRemove.bind(_this);
    _this.onNodeToggle = _this.onNodeToggle.bind(_this);
    return _this;
  }

  _createClass(DropdownTreeSelect, [{
    key: 'notifyChange',
    value: function notifyChange() {
      var _props;

      typeof this.props.onChange === 'function' && (_props = this.props).onChange.apply(_props, arguments);
    }
  }, {
    key: 'createList',
    value: function createList(tree) {
        this.treeManager = new TreeManager();
      return this.treeManager.tree;
    }
  }, {
    key: 'componentWillMount',
    value: function componentWillMount() {
      var tree = this.createList(this.props.data);
      var tags = this.treeManager.getTags();
      this.setState({ tree: tree, tags: tags });
    }
  }, {
    key: 'componentWillReceiveProps',
    value: function componentWillReceiveProps(nextProps) {
      var tree = this.createList(nextProps.data);
      var tags = this.treeManager.getTags();
      this.setState({ tree: tree, tags: tags });
    }
  }, {
    key: 'onDrowdownHide',
    value: function onDrowdownHide() {
      // needed when you click an item in tree and then click back in the input box.
      // react-simple-dropdown behavior is toggle since its single select only
      // but we want the drawer to remain open in this scenario as we support multi select
      if (this.keepDropdownActive) {
        this.dropdown.show();
      } else {
        this.resetSearch();
      }
    }
  }, {
    key: 'onInputChange',
    value: function onInputChange(value) {
      var _treeManager$filterTr = this.treeManager.filterTree(value),
          allNodesHidden = _treeManager$filterTr.allNodesHidden,
          tree = _treeManager$filterTr.tree;

      var searchModeOn = value.length > 0;

      this.setState({ tree: tree, searchModeOn: searchModeOn, allNodesHidden: allNodesHidden });
    }
  }, {
    key: 'onTagRemove',
    value: function onTagRemove(id) {
      this.onCheckboxChange(id, false);
    }
  }, {
    key: 'onNodeToggle',
    value: function onNodeToggle(id) {
      this.treeManager.toggleNodeExpandState(id);
      this.setState({ tree: this.treeManager.tree });
      typeof this.props.onNodeToggle === 'function' && this.props.onNodeToggle(this.treeManager.getNodeById(id));
    }
  }, {
    key: 'onCheckboxChange',
    value: function onCheckboxChange(id, checked) {
      this.treeManager.setNodeCheckedState(id, checked);
      var tags = this.treeManager.getTags();
      this.setState({ tree: this.treeManager.tree, tags: tags });
      this.notifyChange(this.treeManager.getNodeById(id), tags);
    }
  }, {
    key: 'render',
    value: function render() {
      var _this2 = this;

      return __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(
        'div',
        { className: __WEBPACK_IMPORTED_MODULE_2_classnames_bind
default()(this.props.className, 'react-dropdown-tree-select') },
        __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(
          __WEBPACK_IMPORTED_MODULE_3_react_simple_dropdown
default.a,
          { ref: function ref(el) {
              _this2.dropdown = el;
            }, onHide: this.onDrowdownHide },
          __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(
            __WEBPACK_IMPORTED_MODULE_3_react_simple_dropdown__[\"DropdownTrigger\"],
            { className: cx('dropdown-trigger') },
            __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(__WEBPACK_IMPORTED_MODULE_6__input__[\"a\" /* default */], {
              inputRef: function inputRef(el) {
                _this2.searchInput = el;
              },
              tags: this.state.tags,
              placeholderText: this.props.placeholderText,
              onInputChange: this.onInputChange,
              onFocus: function onFocus() {
                _this2.keepDropdownActive = true;
              },
              onBlur: function onBlur() {
                _this2.keepDropdownActive = false;
              },
              onTagRemove: this.onTagRemove })
          ),
          __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(
            __WEBPACK_IMPORTED_MODULE_3_react_simple_dropdown__[\"DropdownContent\"],
            { className: cx('dropdown-content') },
            this.state.allNodesHidden ? __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(
              'span',
              { className: 'no-matches' },
              'No matches found'
            ) : __WEBPACK_IMPORTED_MODULE_0_react
default.a.createElement(__WEBPACK_IMPORTED_MODULE_5__tree__[\"a\" /* default */], { data: this.state.tree,
              searchModeOn: this.state.searchModeOn,
              onAction: this.onAction,
              onCheckboxChange: this.onCheckboxChange,
              onNodeToggle: this.onNodeToggle })
          )
        )
      );
    }
  }]);

  return DropdownTreeSelect;
}(__WEBPACK_IMPORTED_MODULE_0_react__[\"Component\"]);

DropdownTreeSelect.propTypes = {
  data: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.oneOfType([__WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.object, __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.array]).isRequired,
  placeholderText: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.string,
  showDropdown: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.bool,
  className: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.string,
  onChange: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.func,
  onAction: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.func,
  onNodeToggle: __WEBPACK_IMPORTED_MODULE_1_prop_types
default.a.func
};


