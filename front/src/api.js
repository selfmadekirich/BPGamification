export const getAcc = fetch(
  'https://4cea-37-112-237-59.ngrok.io/api/personalpage/1',
).then((response) => response.json())

export const getShop = fetch(
  'https://4cea-37-112-237-59.ngrok.io/api/coinshop/getshop',
).then((response) => response.json())

export const getBoard = fetch(
  'https://4cea-37-112-237-59.ngrok.io/api/leaderboard/getleaders/1 ',
).then((response) => response.json())
