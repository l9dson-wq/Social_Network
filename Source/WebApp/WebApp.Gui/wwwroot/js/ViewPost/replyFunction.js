const replyButtons = document.querySelectorAll(".replyButton");
const replyForms = document.querySelectorAll(".replyForm");
const cancelReplyButtons = document.querySelectorAll(".cancelReplyButton");

replyButtons.forEach((button, index) => {
  button.addEventListener("click", () => {
    // Alternar la clase 'hidden' para mostrar u ocultar el formulario correspondiente
    replyForms[index].classList.toggle("hidden");
  });
});

cancelReplyButtons.forEach((button, index) => {
  button.addEventListener("click", (event) => {
    // Ocultar el formulario al hacer clic en el botón de cancelar y evitar que se envíe el formulario
    replyForms[index].classList.add("hidden");
    event.preventDefault();
  });
});