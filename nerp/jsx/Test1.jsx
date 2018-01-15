<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Document</title>
<link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.3/css/bootstrap.min.css">
<script type="text/javascript" href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.3/js/bootstrap.min.js'></script>
</head>
<body>

  <div className="flex-item">
                <div className="flex-item">
                <label id="minute">00</label>:<label id="second">00</label>
                </div>
               <div class="flex-row">
                  <button className="btn btn-danger " id="record">Record <i className="fa fa-microphone" aria-hidden="true"></i></button>
                  <button className="btn btn-group " id="pause">Pause <i className="fa fa-pause" aria-hidden="true"></i></button>
                  <button className="btn btn-info " id="stop">Stop <i className="fa fa-stop" aria-hidden="true"></i></button>
                  <input type="hidden" id={'hid'+index} />
                  <button className="btn btn-success" id="btnSave" onClick="saveAudio"> Save <i className="fa fa-floppy-o" aria-hidden="true"></i></button>
               </div>
                  <section id="sound-clip"></section>
  </div>

  <script type="text/javascript">
var minutesLabel = document.querySelector('#minutes');
var secondsLabel = document.querySelector('#seconds');
var totalSeconds = 0;
// setInterval(setTime, 1000);

function setTime() {
  ++totalSeconds;
  secondsLabel.innerHTML = pad(totalSeconds % 60);
  minutesLabel.innerHTML = pad(parseInt(totalSeconds / 60));
}

function pad(val) {
  var valString = val + "";
  if (valString.length < 2) {
    return "0" + valString;
  }
  else {
    return valString;
  }
}

var chunks = [];
var record = document.querySelector('#record');
var stop = document.querySelector('#stop');
var soundClips = document.querySelector('#sound-clips');
var pause = document.querySelector('#pause');
// khởi tạo media recoder
// read doc tại.
if (navigator.mediaDevices) {
  console.log('getUserMedia supported.');

  var constraints = { audio: true };

  document.getElementById('record').onclick = function () {
 console.log('Chạy cái gì dây',navigator.mediaDevices);
   navigator.mediaDevices.getUserMedia(constraints)
      .then(function (stream) {
        var mediaRecorder = new MediaRecorder(stream);
        var _time, time = 0;
        //   mediaRecorder.onstop

        if (mediaRecorder.state === "paused") {
            document.querySelector('#record').disabled = true;
          mediaRecorder.resume();
          console.log(mediaRecorder.state);
          //
          _time = setInterval(setTime, 1000);
        }
        else if (mediaRecorder.state !== 'recording') {
          mediaRecorder.start();
          console.log(mediaRecorder.state);
          //
          _time = setInterval(setTime, 1000);
        }
        ///pause onclick
        pause.onclick = function () {

          if (mediaRecorder.state == 'recording') {
        document.querySelector('#record').disabled = true;
            mediaRecorder.pause();
            clearInterval(_time);

          } else {
            mediaRecorder.resume();
            _time = setInterval(setTime, 1000);
          }
          console.log(mediaRecorder.state);

        }
        //stop onclick
        stop.onclick = function () {
          mediaRecorder.stop();
          console.log(mediaRecorder.state);

          clearInterval(_time);
          totalSeconds = 0;
        }

        mediaRecorder.onstop = function (e) {
          document.querySelector('#record').disabled = true;
          document.querySelector('#pause').disabled = true;
          console.log("data available after MediaRecorder.stop() called.");





          var clipContainer = document.createElement('article');
          var clipLabel = document.createElement('p');
          var audio = document.createElement('audio');
          var deleteButton = document.createElement('button');
          deleteButton.className = "btn btn-danger";

          clipContainer.classList.add('clip');
          audio.setAttribute('controls', '');
          deleteButton.innerHTML = "Delete";


          clipContainer.appendChild(audio);
          clipContainer.appendChild(clipLabel);
          clipContainer.appendChild(deleteButton);
          soundClips.appendChild(clipContainer);

          audio.controls = true;
          var blob = new Blob(chunks, { 'type': 'audio/ogg; codecs=opus' });
           var fd = new FormData();
           fd.append('filename', '.wav');
                fd.append('data', blob,'.wav');
                $.ajax({
                    type: 'POST',
                    url: 'ExamResult/UploadBlob',
                    data: fd,
                    processData: false,
                    contentType: false
                }).done(function(data) {

                       console.log(data);
                       $('#hid'+index).val(data);
                });
           console.log(blob);
          var audioURL = URL.createObjectURL(blob);
          audio.src = audioURL;
          var url = document.URL;
          console.log(url);
          console.log(audioURL);
          console.log("recorder stopped");
 $("#hid").val(".wav") ;

          deleteButton.onclick = function (e) {

            evtTgt = e.target;
            evtTgt.parentNode.parentNode.removeChild(evtTgt.parentNode);
            chunks = [];
            document.querySelector('#record').disabled = false;
            document.querySelector('#pause').disabled = false;
          }
        }

        mediaRecorder.ondataavailable = function (e) {

          chunks.push("chunk.edata",e.data);
           console.log(e.data);

          console.log(chunks);

          clearInterval(_time);
          secondsLabel.innerHTML = "00";
          minutesLabel.innerHTML = "00";
        }
      })
  }
}
  </script>

</body>
</html>