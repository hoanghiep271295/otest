﻿var sourcePath;
$(function () {
    $('textarea.contentQG')
        .tinymce({
        // selector: "textarea.NOTESQ",
        /* width and height of the editor */
        width: "100%",
        height: 300,
        theme: "modern",
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak",
            "searchreplace wordcount visualblocks visualchars code fullscreen",
            "insertdatetime media nonbreaking save table contextmenu directionality",
            "emoticons template textcolor colorpicker textpattern powerpaste searchreplace"
        ],
        toolbar:
            "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons | searchreplace",
        fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
        theme_advanced_fonts: "Andale Mono=andale mono,times;" +
           "Arial=arial,helvetica,sans-serif;" +
           "Arial Black=arial black,avant garde;" +
           "Book Antiqua=book antiqua,palatino;" +
           "Comic Sans MS=comic sans ms,sans-serif;" +
           "Courier New=courier new,courier;" +
           "Georgia=georgia,palatino;" +
           "Helvetica=helvetica;" +
           "Impact=impact,chicago;" +
           "Symbol=symbol;" +
           "Tahoma=tahoma,arial,helvetica,sans-serif;" +
           "Terminal=terminal,monaco;" +
           "Times New Roman=times new roman,times;" +
           "Trebuchet MS=trebuchet ms,geneva;" +
           "Verdana=verdana,geneva;" +
           "Webdings=webdings;" +
           "Wingdings=wingdings,zapf dingbats",
        paste_retain_style_properties: "all",
        paste_enable_default_filters: false,
        powerpaste_allow_local_images: true,
        powerpaste_word_import: 'prompt',
        powerpaste_html_import: 'prompt',
        theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

        paste_preprocess: function (pl, o) {
            console.log('Object', o);
            console.log('Content:', o.content);
        },
        file_browser_callback_types: 'file image media',
        paste_data_images: true,
        images_upload_url: '/TinyMce/TinyMceUpload',
        file_picker_callback: function (callback, value, meta) {
            if (meta.filetype === 'image') {
                $('#upload_imageSQ').trigger('click');
                $('#upload_imageSQ')
                    .on('change',
                        function (event) {
                            var file = this.files[0];
                            var path = window.URL.createObjectURL(event.target.files[0]);
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                callback(e.target.result,
                                {
                                    alt: file.name
                                });
                                e.preventDefault();
                            };
                            reader.readAsDataURL(file);
                            event.preventDefault();
                        });
            }
            if (meta.filetype === 'media') {
                $('#upload_mediaSQ').trigger('click');
                $('#upload_mediaSQ')
                    .on('change',
                        function (event) {
                            var file1 = this.files[0];
                            var path1 = window.URL.createObjectURL(event.target.files[0]);
                            var reader1 = new FileReader();
                            console.log('Note QS:', path1);
                            reader1.onload = function (e) {
                                callback(path1, { source2: file1.name, poster: file1.name });
                            };
                            reader1.readAsDataURL(file1);

                        });

            }
        },
        //  media_live_embeds: true,
        video_template_callback: function (data) {
            sourcePath = data.source1;
            uploadFile("#upload_mediaSQ");
            return '<video controls>  <source src="' +
                sourcePath +
                '" type="video/mp4">  Your browser does not support the video tag.</video>';

            //    return '<video controls>  <source src="movie.mp4" type="'+sourcePath+'">  Your browser does not support the video tag.</video>';

            //           return '<iframe width="' + data.width + '" height="' + data.height + '" id="iframe_" src="' + sourcePath + '" width="300" height="150"></iframe>';;

        }
    });
});
$(function () {
    $('textarea.CONTENTQUESTION')
    .tinymce({
        // selector: "textarea.NOTESQ",
        /* width and height of the editor */
        width: "100%",
        height: 300,
        theme: "modern",
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak",
            "searchreplace wordcount visualblocks visualchars code fullscreen",
            "insertdatetime media nonbreaking save table contextmenu directionality",
            "emoticons template textcolor colorpicker textpattern powerpaste searchreplace"
        ],
        toolbar:
            "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons | searchreplace",
        fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
        theme_advanced_fonts: "Andale Mono=andale mono,times;" +
           "Arial=arial,helvetica,sans-serif;" +
           "Arial Black=arial black,avant garde;" +
           "Book Antiqua=book antiqua,palatino;" +
           "Comic Sans MS=comic sans ms,sans-serif;" +
           "Courier New=courier new,courier;" +
           "Georgia=georgia,palatino;" +
           "Helvetica=helvetica;" +
           "Impact=impact,chicago;" +
           "Symbol=symbol;" +
           "Tahoma=tahoma,arial,helvetica,sans-serif;" +
           "Terminal=terminal,monaco;" +
           "Times New Roman=times new roman,times;" +
           "Trebuchet MS=trebuchet ms,geneva;" +
           "Verdana=verdana,geneva;" +
           "Webdings=webdings;" +
           "Wingdings=wingdings,zapf dingbats",
        paste_retain_style_properties: "all",
        paste_enable_default_filters: false,
        powerpaste_allow_local_images: true,
        powerpaste_word_import: 'prompt',
        powerpaste_html_import: 'prompt',
        theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

        paste_preprocess: function(pl, o) {
            console.log('Object', o);
            console.log('Content:', o.content);
        },
        file_browser_callback_types: 'file image media',
        paste_data_images: true,
        images_upload_url: '/TinyMce/TinyMceUpload',
        file_picker_callback: function(callback, value, meta) {
            if (meta.filetype === 'image') {
                $('#upload_imageSQ').trigger('click');
                $('#upload_imageSQ')
                    .on('change',
                        function(event) {
                            var file = this.files[0];
                            var path = window.URL.createObjectURL(event.target.files[0]);
                            var reader = new FileReader();
                            reader.onload = function(e) {
                                callback(e.target.result,
                                {
                                    alt: file.name
                                });
                                e.preventDefault();
                            };
                            reader.readAsDataURL(file);
                            event.preventDefault();
                        });
            }
            if (meta.filetype === 'media') {
                $('#upload_mediaSQ').trigger('click');
                $('#upload_mediaSQ')
                    .on('change',
                        function(event) {
                            var file1 = this.files[0];
                            var path1 = window.URL.createObjectURL(event.target.files[0]);
                            var reader1 = new FileReader();
                            console.log('Note QS:', path1);
                            reader1.onload = function(e) {
                                callback(path1, { source2: file1.name, poster: file1.name });
                            };
                            reader1.readAsDataURL(file1);

                        });

            }
        },
        //  media_live_embeds: true,
        video_template_callback: function(data) {
            sourcePath = data.source1;
            uploadFile("#upload_mediaSQ");
            return '<video controls>  <source src="' +
                sourcePath +
                '" type="video/mp4">  Your browser does not support the video tag.</video>';

            //    return '<video controls>  <source src="movie.mp4" type="'+sourcePath+'">  Your browser does not support the video tag.</video>';

            //           return '<iframe width="' + data.width + '" height="' + data.height + '" id="iframe_" src="' + sourcePath + '" width="300" height="150"></iframe>';;

        }
    });
});
$(function () {
    $('textarea.NOTESQ')
        .tinymce({
            // selector: "textarea.NOTESQ",
            /* width and height of the editor */
            width: "100%",
            height: 300,
            theme: "modern",
            plugins: [
                "advlist autolink lists link image charmap print preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars code fullscreen",
                "insertdatetime media nonbreaking save table contextmenu directionality",
                "emoticons template textcolor colorpicker textpattern powerpaste searchreplace"
            ],
            toolbar:
                "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons | searchreplace",
            fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
            theme_advanced_fonts: "Andale Mono=andale mono,times;" +
               "Arial=arial,helvetica,sans-serif;" +
               "Arial Black=arial black,avant garde;" +
               "Book Antiqua=book antiqua,palatino;" +
               "Comic Sans MS=comic sans ms,sans-serif;" +
               "Courier New=courier new,courier;" +
               "Georgia=georgia,palatino;" +
               "Helvetica=helvetica;" +
               "Impact=impact,chicago;" +
               "Symbol=symbol;" +
               "Tahoma=tahoma,arial,helvetica,sans-serif;" +
               "Terminal=terminal,monaco;" +
               "Times New Roman=times new roman,times;" +
               "Trebuchet MS=trebuchet ms,geneva;" +
               "Verdana=verdana,geneva;" +
               "Webdings=webdings;" +
               "Wingdings=wingdings,zapf dingbats",
            paste_retain_style_properties: "all",
            paste_enable_default_filters: false,
            powerpaste_allow_local_images: true,
            powerpaste_word_import: 'prompt',
            powerpaste_html_import: 'prompt',
            theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

            paste_preprocess: function(pl, o) {
                console.log('Object', o);
                console.log('Content:', o.content);
            },
            file_browser_callback_types: 'file image media',
            paste_data_images: true,
            images_upload_url: '/TinyMce/TinyMceUpload',
            file_picker_callback: function(callback, value, meta) {
                if (meta.filetype === 'image') {
                    $('#upload_imageSQ').trigger('click');
                    $('#upload_imageSQ')
                        .on('change',
                            function(event) {
                                var file = this.files[0];
                                var path = window.URL.createObjectURL(event.target.files[0]);
                                var reader = new FileReader();
                                reader.onload = function(e) {
                                    callback(e.target.result,
                                    {
                                        alt: file.name
                                    });
                                    e.preventDefault();
                                };
                                reader.readAsDataURL(file);
                                event.preventDefault();
                            });
                }
                if (meta.filetype === 'media') {
                    $('#upload_mediaSQ').trigger('click');
                    $('#upload_mediaSQ')
                        .on('change',
                            function(event) {
                                var file1 = this.files[0];
                                var path1 = window.URL.createObjectURL(event.target.files[0]);
                                var reader1 = new FileReader();
                                console.log('Note QS:', path1);
                                reader1.onload = function(e) {
                                    callback(path1, { source2: file1.name, poster: file1.name });
                                };
                                reader1.readAsDataURL(file1);

                            });

                }
            },
          //  media_live_embeds: true,
            video_template_callback: function(data) {
                sourcePath = data.source1;
                uploadFile("#upload_mediaSQ");
                return '<video controls>  <source src="' +
                    sourcePath +
                    '" type="video/mp4">  Your browser does not support the video tag.</video>';

    //    return '<video controls>  <source src="movie.mp4" type="'+sourcePath+'">  Your browser does not support the video tag.</video>';

     //           return '<iframe width="' + data.width + '" height="' + data.height + '" id="iframe_" src="' + sourcePath + '" width="300" height="150"></iframe>';;

                    }
        });
});
$(function () {
    $('textarea.CONTENTIMGQUESTION')
        .tinymce({
            width: "100%",
            height: 300,
            theme: "modern",
            plugins: [
                "advlist autolink lists link image charmap print preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars code fullscreen",
                "insertdatetime media nonbreaking save table contextmenu directionality",
                "emoticons template textcolor colorpicker textpattern powerpaste"
                    ],
            toolbar: "image",
            file_browser_callback_types: 'image',
            paste_data_images: true,
            images_upload_url: '/TinyMce/TinyMceUpload',
            file_picker_callback: function(callback, value, meta) {
                if (meta.filetype === 'image') {
                    $('#upload_imageSQ').trigger('click');
                    $('#upload_imageSQ')
                        .on('change',
                            function() {
                                var file = this.files[0];
                                var path = window.URL.createObjectURL(event.target.files[0]);
                                var reader = new FileReader();
                                reader.onload = function(e) {
                                    callback(e.target.result,
                                    {
                                        alt: file.name
                                    });
                                };
                                reader.readAsDataURL(file);
                            });
                }
                if (meta.filetype === 'media') {
                    $('#upload_mediaSQ').trigger('click');
                    $('#upload_mediaSQ')
                        .on('change',
                            function() {
                                var file1 = this.files[0];
                                var path1 = window.URL.createObjectURL(event.target.files[0]);
                                var reader1 = new FileReader();
                                console.log('CONTENTQUESTION:', path1);
                                reader1.onload = function(e) {
                                    callback(path1, { source2: file1.name, poster: file1.name });
                                };
                                reader1.readAsDataURL(file1);

                            });

                }
            },
        });
});
$(function () {
    $('textarea.CONTENTANSWER')
       .tinymce({
           // selector: "textarea.NOTESQ",
           /* width and height of the editor */
           width: "100%",
           height: 300,
           theme: "modern",
           plugins: [
               "advlist autolink lists link image charmap print preview hr anchor pagebreak",
               "searchreplace wordcount visualblocks visualchars code fullscreen",
               "insertdatetime media nonbreaking save table contextmenu directionality",
               "emoticons template textcolor colorpicker textpattern powerpaste searchreplace"
           ],
           toolbar:
               "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons | searchreplace",
           fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
           theme_advanced_fonts: "Andale Mono=andale mono,times;" +
              "Arial=arial,helvetica,sans-serif;" +
              "Arial Black=arial black,avant garde;" +
              "Book Antiqua=book antiqua,palatino;" +
              "Comic Sans MS=comic sans ms,sans-serif;" +
              "Courier New=courier new,courier;" +
              "Georgia=georgia,palatino;" +
              "Helvetica=helvetica;" +
              "Impact=impact,chicago;" +
              "Symbol=symbol;" +
              "Tahoma=tahoma,arial,helvetica,sans-serif;" +
              "Terminal=terminal,monaco;" +
              "Times New Roman=times new roman,times;" +
              "Trebuchet MS=trebuchet ms,geneva;" +
              "Verdana=verdana,geneva;" +
              "Webdings=webdings;" +
              "Wingdings=wingdings,zapf dingbats",
           paste_retain_style_properties: "all",
           paste_enable_default_filters: false,
           powerpaste_allow_local_images: true,
           powerpaste_word_import: 'prompt',
           powerpaste_html_import: 'prompt',
           theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

           paste_preprocess: function (pl, o) {
               console.log('Object', o);
               console.log('Content:', o.content);
           },
           file_browser_callback_types: 'file image media',
           paste_data_images: true,
           images_upload_url: '/TinyMce/TinyMceUpload',
           file_picker_callback: function (callback, value, meta) {
               if (meta.filetype === 'image') {
                   $('#upload_imageSQ').trigger('click');
                   $('#upload_imageSQ')
                       .on('change',
                           function (event) {
                               var file = this.files[0];
                               var path = window.URL.createObjectURL(event.target.files[0]);
                               var reader = new FileReader();
                               reader.onload = function (e) {
                                   callback(e.target.result,
                                   {
                                       alt: file.name
                                   });
                                   e.preventDefault();
                               };
                               reader.readAsDataURL(file);
                               event.preventDefault();
                           });
               }
               if (meta.filetype === 'media') {
                   $('#upload_mediaSQ').trigger('click');
                   $('#upload_mediaSQ')
                       .on('change',
                           function (event) {
                               var file1 = this.files[0];
                               var path1 = window.URL.createObjectURL(event.target.files[0]);
                               var reader1 = new FileReader();
                               console.log('Note QS:', path1);
                               reader1.onload = function (e) {
                                   callback(path1, { source2: file1.name, poster: file1.name });
                               };
                               reader1.readAsDataURL(file1);

                           });

               }
           },
           //  media_live_embeds: true,
           video_template_callback: function (data) {
               sourcePath = data.source1;
               uploadFile("#upload_mediaSQ");
               return '<video controls>  <source src="' +
                   sourcePath +
                   '" type="video/mp4">  Your browser does not support the video tag.</video>';

               //    return '<video controls>  <source src="movie.mp4" type="'+sourcePath+'">  Your browser does not support the video tag.</video>';

               //           return '<iframe width="' + data.width + '" height="' + data.height + '" id="iframe_" src="' + sourcePath + '" width="300" height="150"></iframe>';;

           }
       });
});
function uploadFile(id) {
    // upload file
    var fileUpload = $(id);
    var files = fileUpload.get(0).files;
    // Create FormData object 
    var fileData = new FormData();
    //var formatted = $("#CODEVIEW").val();
    //console.log('Upload file to codeview:',formatted);
    // Looping over all files and add it to FormData object  
    for (var i = 0; i < files.length; i++) {
        fileData.append(sourcePath, files[i]);
    }
    $.ajax({
        url: '/TinyMce/TinyMceUpload',
        type: "POST",
        contentType: false, // Not to set any content header  
        processData: false, // Not to process data  
        data: fileData,
        success: function (data) {
            log.show("Upload file thành công", true);
        },
        error: function (err) {
            log.show("Upload file thất bại", false);
        }
    });
}
function initEditor(classname, callbackfunction) {
    $('textarea.' + classname).tinymce({
        //   selector: "textarea.CONTENTQUESTION",
        /* width and height of the editor */
        width: "100%",
        height: 300,
        theme: "modern",
        // begin paste
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak",
            "searchreplace wordcount visualblocks visualchars code fullscreen",
            "insertdatetime media nonbreaking save table contextmenu directionality",
            "emoticons template textcolor colorpicker textpattern powerpaste"
        ],
        setup: function (ed) {
            console.log('Finish init the editor');
            if (callbackfunction !== null && callbackfunction !== 'undefined') {
                ed.on('init', callbackfunction);
            }
            //ed.on('init', function (args) {
            //    console.log('Doi tuong',args.target.id);
            //});

        },
        toolbar:
            "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
        fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
        formats: {
            alignleft: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'left' },
            aligncenter: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'center' },
            alignright: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'right' },
            alignjustify: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'full' },
            underline: { inline: 'span', 'classes': 'underline', exact: true },
            strikethrough: { inline: 'del' },
            forecolor: { inline: 'span', classes: 'forecolor', styles: { color: '%value' } },
            hilitecolor: { inline: 'span', classes: 'hilitecolor', styles: { backgroundColor: '%value' } },
            custom_format: { block: 'h1', attributes: { title: 'Header' }, styles: { color: 'red' } }
        },
        paste_retain_style_properties: "all",
        paste_enable_default_filters: false,
        powerpaste_allow_local_images: true,
        powerpaste_word_import: 'prompt',
        powerpaste_html_import: 'prompt',
        theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

        paste_preprocess: function (pl, o) {
            console.log('Object', o);
            console.log('Content:', o.content);
        },
        // end paste
        file_browser_callback_types: 'file image media',
        paste_data_images: true,
        images_upload_url: '/TinyMce/TinyMceUpload',
        file_picker_callback: function (callback, value, meta) {
            if (meta.filetype == 'image') {
                $('#upload_imageQG').trigger('click');
                $('#upload_imageQG')
                    .on('change',
                        function () {
                            var file = this.files[0];
                            var path = window.URL.createObjectURL(event.target.files[0]);
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                callback(e.target.result,
                                {
                                    alt: file.name
                                });
                            };
                            reader.readAsDataURL(file);
                        });
            }
            if (meta.filetype == 'media') {
                $('#upload_mediaQG').trigger('click');
                $('#upload_mediaQG')
                    .on('change',
                        function () {
                            var file1 = this.files[0];
                            var path1 = window.URL.createObjectURL(event.target.files[0]);
                            var reader1 = new FileReader();
                            console.log('Chi tiết câu hỏi:', path1);
                            reader1.onload = function (e) {
                                callback(path1, { source2: file1.name, poster: file1.name });
                            };
                            reader1.readAsDataURL(file1);

                        });

            }
        },
        //  media_live_embeds: true,
        video_template_callback: function (data) {
            sourcePath = data.source1;
            uploadFile("#upload_imageQG");
            return '<video controls>  <source src="' +
                sourcePath +
                '" type="video/mp4">  Your browser does not support the video tag.</video>';

            //        return '<iframe width="' + data.width + '" height="' + data.height + '" src="' + data.source1 + '" width="300" height="150"></iframe>';;

        }
    });
}
/**
 * Thiết lập
 * @param {} id 
 * @param {} callbackfunction 
 * @returns {} 
 */
function initEditorByID(id, callbackfunction) {
    console.log('init editor for ',id);
    $('#'+id).tinymce({
        //   selector: "textarea.CONTENTQUESTION",
        /* width and height of the editor */
        width: "100%",
        height: 300,
        theme: "modern",
        // begin paste
        plugins: [
            "advlist autolink lists link image charmap print preview hr anchor pagebreak",
            "searchreplace wordcount visualblocks visualchars code fullscreen",
            "insertdatetime media nonbreaking save table contextmenu directionality",
            "emoticons template textcolor colorpicker textpattern powerpaste"
        ],
        setup: function (ed) {
            console.log('Setup for ', id);
            if (callbackfunction !== null && callbackfunction !== 'undefined') {
                ed.on('init', callbackfunction);
            }
        },
        toolbar:
            "fontsizeselect fontselect | insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
        fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
        formats: {
            alignleft: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'left' },
            aligncenter: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'center' },
            alignright: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'right' },
            alignjustify: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'full' },
            underline: { inline: 'span', 'classes': 'underline', exact: true },
            strikethrough: { inline: 'del' },
            forecolor: { inline: 'span', classes: 'forecolor', styles: { color: '%value' } },
            hilitecolor: { inline: 'span', classes: 'hilitecolor', styles: { backgroundColor: '%value' } },
            custom_format: { block: 'h1', attributes: { title: 'Header' }, styles: { color: 'red' } }
        },
        paste_retain_style_properties: "all",
        paste_enable_default_filters: false,
        powerpaste_allow_local_images: true,
        powerpaste_word_import: 'prompt',
        powerpaste_html_import: 'prompt',
        theme_advanced_buttons3_add: "pastetext,pasteword,selectall",

        paste_preprocess: function (pl, o) {
            console.log('Object', o);
            console.log('Content:', o.content);
        },
        // end paste
        file_browser_callback_types: 'file image media',
        paste_data_images: true,
        images_upload_url: '/TinyMce/TinyMceUpload',
        file_picker_callback: function (callback, value, meta) {
            if (meta.filetype == 'image') {
                $('#' + id + '_uploadfileimage').trigger('click');
                $('#' + id + '_uploadfileimage')
                    .on('change',
                        function () {
                            var file = this.files[0];
                            var path = window.URL.createObjectURL(event.target.files[0]);
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                callback(e.target.result,
                                {
                                    alt: file.name
                                });
                            };
                            reader.readAsDataURL(file);
                        });
            }
            if (meta.filetype == 'media') {
                $('#' + id + '_uploadfilemedia').trigger('click');
                $('#' + id + '_uploadfilemedia')
                    .on('change',
                        function () {
                            var file1 = this.files[0];
                            var path1 = window.URL.createObjectURL(event.target.files[0]);
                            var reader1 = new FileReader();
//                            console.log('Chi tiết câu hỏi:', path1);
                            reader1.onload = function (e) {
                                callback(path1, { source2: file1.name, poster: file1.name });
                            };
                            reader1.readAsDataURL(file1);

                        });

            }
        },
        //  media_live_embeds: true,
        video_template_callback: function (data) {
            sourcePath = data.source1;
            uploadFile('#' + id + '_uploadfilemedia');
            return '<video controls>  <source src="' +
                sourcePath +
                '" type="video/mp4">  Your browser does not support the video tag.</video>';

            //        return '<iframe width="' + data.width + '" height="' + data.height + '" src="' + data.source1 + '" width="300" height="150"></iframe>';;

        }
    });
}