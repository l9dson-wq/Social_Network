const login = document.getElementById('LogIn');
const singup = document.getElementById('SingUp');
const loginLink = document.getElementById('LogInLink');
const SignupLink = document.getElementById('SingUpLink');
const nextButton = document.getElementById('NextButton');
const userInfo = document.getElementById('userInfo');
const userProfileInfo = document.getElementById('UserProfileInfo');
const backButton = document.getElementById('BackButton');
const saveButton = document.getElementById('SaveButton');

loginLink.addEventListener('click', () => {
  if ( !login.classList.contains('hidden') ) {

    login.classList.add('hidden');

    singup.classList.remove('hidden');

  } else {

    login.classList.remove('hidden');

    singup.classList.add('hidden');

  }
});

SignupLink.addEventListener('click', () => {
  if ( !singup.classList.contains('hidden') ) {

    singup.classList.add('hidden');

    login.classList.remove('hidden');

  } else { 

    singup.classList.remove('hidden');

    login.classList.add('hidden');

  }
});

nextButton.addEventListener('click', () => {
  if (userProfileInfo.classList.contains('hidden')){
    userProfileInfo.classList.remove('hidden');
    backButton.classList.remove('hidden');
    saveButton.classList.remove('hidden');
    nextButton.classList.add('hidden');
    userInfo.classList.add('hidden');
  } 
});

backButton.addEventListener('click', () => {
  if (!userProfileInfo.classList.contains('hidden')){
    userProfileInfo.classList.add('hidden');
    backButton.classList.add('hidden');
    saveButton.classList.add('hidden');
    nextButton.classList.remove('hidden');
    userInfo.classList.remove('hidden');
  }
});