    var minutesLabel = document.querySelector('#minutes'); var secondsLabel = document.querySelector('#seconds'); var totalSeconds = 0;
             function setTime() { ++totalSeconds;secondsLabel.innerHTML = pad(totalSeconds % 60);minutesLabel.innerHTML = pad(parseInt(totalSeconds / 60));}
             function pad(val) { var valString = val + ""; if (valString.length < 2) {return "0" + valString;} else { return valString; }}
             var chunks = [];
              var record = document.querySelector('#record');var pause = document.querySelector('#pause');var stop = document.querySelector('#stop');
              var soundClips = document.querySelector('.sound-clips');var canvas = document.querySelector('.visualizer');var mainSection = document.querySelector('.main-controls');
            // disable stop button while not recording
            // visualiser setup - create web audio api context and canvas
            var audioCtx = new (window.AudioContext || webkitAudioContext)();
            var canvasCtx = canvas.getContext("2d");
            if (navigator.mediaDevices) {
              console.log('getUserMedia supported.');
             var constraints = { audio: true };
             record.onclick = function() {
             navigator.mediaDevices.getUserMedia(constraints)
             .then(function (stream) {
             var mediaRecorder = new MediaRecorder(stream);
            var _time, time = 0;
              visualize(stream);
              if (mediaRecorder.state === "paused") {
                   document.querySelector('#record').disabled = true;
                   mediaRecorder.resume();
                   console.log(mediaRecorder.state);
                   _time = setInterval(setTime, 1000);
               }
               else if (mediaRecorder.state !== 'recording') {
                   mediaRecorder.start();
                   console.log(mediaRecorder.state);
                   _time = setInterval(setTime, 1000);
               }
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

    stop.onclick = function() {
      debugger
      console.log(mediaRecorder.state);
      mediaRecorder.stop();
      record.style.background = "";
      record.style.color = "";
      stop.disabled = true;
      record.disabled = false;
       clearInterval(_time);
       totalSeconds = 0;
    }
    mediaRecorder.onstop = function(e) {
      document.querySelector('#record').disabled = true;
      document.querySelector('#pause').disabled = true;
      var clipName = prompt('Enter a name for your sound clip?','My unnamed clip');
      var clipContainer = document.createElement('article');
      var clipLabel = document.createElement('p');
      var audio = document.createElement('audio');
      var deleteButton = document.createElement('button');
      clipContainer.classList.add('clip');
      audio.setAttribute('controls', '');
      deleteButton.textContent = 'Delete';
      deleteButton.className = 'delete';
      if(clipName === null) {
        clipLabel.textContent = 'My unnamed clip';
      } else {clipLabel.textContent = clipName;}
      clipContainer.appendChild(audio);
      clipContainer.appendChild(clipLabel);
      clipContainer.appendChild(deleteButton);
      soundClips.appendChild(clipContainer);
      audio.controls = true;
      var blob = new Blob(chunks, { 'type' : 'audio/ogg; codecs=opus' });
         var fd = new FormData();
           fd.append('filename', '.wav');
           fd.append('data', blob, '.wav');
           $.ajax({
               type: 'POST',
               url: '/ExamResult/UploadBlob',
               data: fd,
               processData: false,
               contentType: false
           }).done(function (data) {
               console.log(data);
           });


      var audioURL = window.URL.createObjectURL(blob);
      audio.src = audioURL;

      deleteButton.onclick = function(e) {
       evtTgt = e.target;
       chunks = [];
       evtTgt.parentNode.parentNode.removeChild(evtTgt.parentNode);
           document.querySelector('#record').disabled = false;
      document.querySelector('#pause').disabled = false;
      }
    }

    mediaRecorder.ondataavailable = function(e) {
      chunks.push(e.data);
         clearInterval(_time);
       secondsLabel.innerHTML = "00";
       minutesLabel.innerHTML = "00";
    }
  })
}
}
else {
   console.log('getUserMedia not supported on your browser!');
}

function visualize(stream) {
  var source = audioCtx.createMediaStreamSource(stream);

  var analyser = audioCtx.createAnalyser();
  analyser.fftSize = 2048;
  var bufferLength = analyser.frequencyBinCount;
  var dataArray = new Uint8Array(bufferLength);

  source.connect(analyser);
  draw()

  function draw() {
    WIDTH = canvas.width
    HEIGHT = canvas.height;

    requestAnimationFrame(draw);

    analyser.getByteTimeDomainData(dataArray);

    canvasCtx.fillStyle = 'rgb(200, 200, 200)';
    canvasCtx.fillRect(0, 0, WIDTH, HEIGHT);

    canvasCtx.lineWidth = 2;
    canvasCtx.strokeStyle = 'rgb(0, 0, 0)';

    canvasCtx.beginPath();

    var sliceWidth = WIDTH * 1.0 / bufferLength;
    var x = 0;
    for(var i = 0; i < bufferLength; i++) {

      var v = dataArray[i] / 128.0;
      var y = v * HEIGHT/2;

      if(i === 0) {
        canvasCtx.moveTo(x, y);
      } else {
        canvasCtx.lineTo(x, y);
      }

      x += sliceWidth;
    }

    canvasCtx.lineTo(canvas.width, canvas.height/2);
    canvasCtx.stroke();

  }
}
        window.onresize = function() {
          canvas.width = mainSection.offsetWidth;
        }
        window.onresize();