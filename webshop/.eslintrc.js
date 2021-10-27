module.exports = {
  root: true,
  env: {
    node: true
  },
  'extends': [
    'plugin:vue/essential',
    'eslint:recommended'
  ],
  parserOptions: {
    ecmaVersion: 2020
  },
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-param-reassign': 'off',
    'arrow-body-style': 'off',
    'arrow-parens': 'off',
    'array-callback-return': 'off',
    'linebreak-style': 'off',
    'max-len': 'off',
    'comma-dangle': 'off',
    'prefer-destructuring': 'off',
  }
}
