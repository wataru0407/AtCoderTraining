const express = require('express');
const mysql = require('mysql');
const app = express();
const port = 3000;

const connection = mysql.createConnection({
  host: '',
  //host: 'localhost',
  user: 'admin',
  //user: 'root',
  password: '',
  database: ''
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

// const heroes = [
//     { id: 11, name: 'Dr Nice' },
//     { id: 12, name: 'Narco' },
//     { id: 13, name: 'Bombasto' },
//     { id: 14, name: 'Celeritas' },
//     { id: 15, name: 'Magneta' },
//     { id: 16, name: 'RubberMan' },
//     { id: 17, name: 'Dynama' },
//     { id: 18, name: 'Dr IQ' },
//     { id: 19, name: 'Magma' },
//     { id: 20, name: 'Tornado' },
// ];

app.get("/api/heroes", function(req, res, ){
    // res.json(heroes);
    connection.query(
      'SELECT * FROM angular_tutorial.heroes',
      (error, results) => {
        console.log("/api/heroes");
        console.log(results);
        res.json(results);
      }
    );
});

app.get("/api/heroes/:id", function(req, res, next){
    //const hero = heroes.find(x => x.id == req.params.id);
    connection.query(
      `SELECT * FROM angular_tutorial.heroes where id = ${req.params.id}`,
      (error, results) => {
        console.log("/api/heroes/:id");
        console.log(results);
        const hero = results[0];
        res.json(hero);
      }
    );
    //res.json(hero);
});