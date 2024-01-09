document.addEventListener('DOMContentLoaded', function () {
  const maxLength = 60;
  const descriptionTexts = document.querySelectorAll('.descriptionTextReplies');

  descriptionTexts.forEach(descriptionText => {
    const originalText = descriptionText.textContent;
    const truncatedText = originalText.length > maxLength ? originalText.substring(0, maxLength) + '...' : originalText;

    if (originalText.length > maxLength) {
      const toggleButton = document.createElement('span');
      toggleButton.className = 'hover:cursor-pointer hover:underline underline-offset-2 text-xs text-blue-600';
      toggleButton.textContent = 'Show more';

      descriptionText.textContent = truncatedText;
      descriptionText.insertAdjacentElement('afterend', toggleButton);

      toggleButton.addEventListener('click', function () {
        descriptionText.textContent = descriptionText.textContent === truncatedText ? originalText : truncatedText;
        toggleButton.textContent = descriptionText.textContent === truncatedText ? 'Show more' : 'Show less';
      });
    }
  });
});