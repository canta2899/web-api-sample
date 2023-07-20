import { Api } from "./generated/Api";

const api = new Api({baseUrl: "http://localhost:5259"});

api.articlesList({ name: "Kinder"})
  .then(e => e.json())
  .then(d => {
    console.log("\nArticles about \"Kinder\"");
    console.log(d);
  })
  .catch(err => console.log(`Error: ${err}`));

api.articlesShopDetail(2)
  .then(e => e.json())
  .then(d => {
    console.log("\nArticles for shop 2");
    console.log(d);
  })
  .catch(err => console.log(`Error: ${err}`));

