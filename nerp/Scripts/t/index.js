import DropdownTreeSelect from '../../../src'
import data from './demo-data.json'


ReactDOM.render(
<DropdownTreeSelect 
    data={data} 
    onChange={onChange} 
    onAction={onAction} 
    onNodeToggle={onNodeToggle} 
    className="bootstrap-demo"
/>, document.getElementById('app'))
