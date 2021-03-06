module.exports = {
    purge: {
        enabled: true,
        content: [
            './**/*.html',
            './**/*.cshtml',
            './**/*.razor'
        ],
    },
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {},
    },
    variants: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/typography'),
        require('daisyui'),
    ],
}
