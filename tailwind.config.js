/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Components/**/*.{razor,cshtml,html}",
    "./Pages/**/*.{razor,cshtml,html}",
    "./wwwroot/**/*.{html,js}"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
