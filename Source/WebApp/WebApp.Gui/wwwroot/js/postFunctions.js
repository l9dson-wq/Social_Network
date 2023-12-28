const imgPost = document.getElementById("imgPostContainer");

const imgPostButton = document.getElementById("imgPostButton");

const postDescription = document.getElementById("postDescription");

const postButton = document.getElementById("postButton");

const postLinkButton = document.getElementById("postLinkButton");

imgPostButton.addEventListener("click", () => {

  if (imgPost.classList.contains("hidden")) {
    imgPost.classList.remove("hidden");
    postDescription.classList.add("hidden");
  }

  if (postButton.classList.contains("bg-blue-100")) {
    postButton.classList.remove("bg-blue-100");
    imgPostButton.classList.add("bg-blue-100");
  }

  //if (postButton.classList.contains("border-b")) {
  //  postButton.classList.remove("border-b","border-b-blue-500","border-b-2");
  //  imgPostButton.classList.add("border-b","border-b-blue-500","border-b-2");
  //}

});

postButton.addEventListener("click", () => {

  if (postDescription.classList.contains("hidden")) {
    postDescription.classList.remove("hidden")
    imgPost.classList.add("hidden");
  }

  if (!postDescription.classList.contains("bg-blue-100")) {
    postButton.classList.add("bg-blue-100");
    imgPostButton.classList.remove("bg-blue-100");
  }

  //if (!postButton.classList.contains("border-b")) {
  //  postButton.classList.add("border-b","border-b-blue-500","border-b-2");
  //  imgPostButton.classList.remove("border-b","border-b-blue-500","border-b-2");
  //}

});