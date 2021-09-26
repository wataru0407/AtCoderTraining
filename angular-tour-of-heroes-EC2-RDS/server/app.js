const e = require('express');
const express = require('express');

const mysql = require('mysql');
const app = express();
const port = 3000;

app.use(express.json())
app.use(express.urlencoded({ extended: true }));

require('dotenv').config();

const connection = mysql.createConnection({
  host: process.env.HOST,
  user: process.env.USER,
  password: process.env.PASSWORD,
  database: process.env.DATABASE,
});

connection.connect((err) => {
  if (err) {
    console.log('error connecting: ' + err.stack);
    return;
  }
  console.log('success');
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
});

app.get("/api/heroes", function(req, res, next){
    connection.query(
      'SELECT * FROM heroes',
      (error, results) => {
        console.log("/api/heroes");
        console.log(results);
        const searchName = req.query.name;
        if (searchName) {
          const rec = results.filter(item => item.name.includes(searchName));
          res.json(rec);
        } else {
          res.json(results);
        }
      }
    );
});

app.get("/api/heroes/:id", function(req, res, next){
    //const hero = heroes.find(x => x.id == req.params.id);
    connection.query(
      `SELECT * FROM heroes where id = ${req.params.id}`,
      (error, results) => {
        console.log("/api/heroes/:id");
        console.log(results);
        const hero = results[0];
        res.json(hero);
      }
    );
    //res.json(hero);
});

app.get("/api/heroes/:id", function(req, res, next){
  //const hero = heroes.find(x => x.id == req.params.id);
  connection.query(
    `SELECT * FROM heroes where id = ${req.params.id}`,
    (error, results) => {
      console.log("/api/heroes/:id");
      console.log(results);
      const hero = results[0];
      res.json(hero);
    }
  );
  //res.json(hero);
});

// app.put("/api/heroes", function(req, res, next){
//   //const hero = heroes.find(x => x.id == req.params.id);
//   connection.query(
//     `UPDATE heroes set name = '${req.params.name}' where id = ${req.params.id}`,
//     `SELECT * FROM angular_tutorial.heroes where id = ${req.params.id}`,
//     (error, results) => {
//       console.log(results);
//       const hero = results[0];
//       res.json(hero);
//     }
//   );
//   //res.json(hero);
// });

app.put("/api/heroes", (req, res) => {
  console.log("post start");
  const id = req.body.id;
  const name = req.body.name;
  console.log(name);
  const sql = `UPDATE heroes SET name = '${name}' where id = ${id}`;
  console.log(sql);
  connection.query(sql, (err, result) => {
    if (err) throw err;
    console.log(result);
    //const insertId = result.insertId;
    //const resHero = {id: insertId, name: name};
    //res.json(resHero);
  })
});


app.post("/api/heroes", (req, res) => {
  console.log("put start");
  const name = req.body.name;
  console.log(name);
  const sql = `INSERT INTO heroes(name) VALUES('${name}')`;
  console.log(sql);
  connection.query(sql, (err, result) => {
    if (err) throw err;
    console.log(result);
    const insertId = result.insertId;
    const resHero = {id: insertId, name: name};
    res.json(resHero);
  })
});

app.delete("/api/heroes/:id", (req, res) => {
  console.log("delete start");
  const deleteId = req.params.id;
  const sql = `DELETE FROM heroes where id = ${deleteId}`;
  console.log(sql);
  connection.query(sql, (err, result) => {
    if (err) throw err;
    console.log(result);
    // const insertId = result.insertId;
    // const resHero = {id: insertId, name: name};
    // res.json(resHero);
  })
});


// app.post("/api/heroes", function(req, res, next){
//   //const hero = heroes.find(x => x.id == req.params.id);
//   // const sql = `INSERT INTO heroes VALUES('${req.name}')`;
//   const sql = `INSERT INTO heroes SET ?`;

//   console.log(req.body);
//   connection.query(sql, function(err, result, fields){
//     if (err) throw err;
//     console.log(result);
//     res.send('完了');
//   })
//   // console.log(sql);
//   // connection.query(
//   //   `INSERT INTO heroes VALUES('${req.params.name}')`,
//   //   (error, results) => {
//   //     console.log(results);
//   //     const hero = results[0];
//   //     res.json(hero);
//   //   }
//   // );
//   //res.json(hero);
// });
