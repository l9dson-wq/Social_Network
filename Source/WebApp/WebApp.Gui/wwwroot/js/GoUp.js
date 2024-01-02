// GO UP FUNCTION --------------------------
window.onscroll = function() {
  mostrarOcultarBoton();
};

function mostrarOcultarBoton() {
  var boton = document.getElementById("volver-arriba");

  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    boton.style.display = "block";
  } else {
    boton.style.display = "none";
  }
}

function volverArriba() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}

//--------------------------