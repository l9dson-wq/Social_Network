const nextButton = document.getElementById('NextButton');
const userInfo = document.getElementById('userInfo');
const userProfileInfo = document.getElementById('UserProfileInfo');
const backButton = document.getElementById('BackButton');
const saveButton = document.getElementById('SaveButton');

nextButton.addEventListener('click', () => {
  if (userProfileInfo.classList.contains('hidden')) {
    userProfileInfo.classList.remove('hidden');
    backButton.classList.remove('hidden');
    saveButton.classList.remove('hidden');
    nextButton.classList.add('hidden');
    userProfileInfo.classList.add('flex');
    userInfo.classList.add('hidden');
  }
});

backButton.addEventListener('click', () => {
  if (!userProfileInfo.classList.contains('hidden')) {
    userProfileInfo.classList.add('hidden');
    userProfileInfo.classList.remove('flex');
    backButton.classList.add('hidden');
    saveButton.classList.add('hidden');
    nextButton.classList.remove('hidden');
    userInfo.classList.remove('hidden');
  }
});