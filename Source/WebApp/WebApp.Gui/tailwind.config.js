/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml',
  ],
  theme: {
    extend: {
      width: {
        '640': '640px'
      }
    },
  },
  plugins: [
    require('tailwindcss-animated')
  ],
}

