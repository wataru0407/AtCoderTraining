const express = require('express');
const mysql = require('mysql');
const app = express();
const port = 3000;

// RESTAPIのbodyを使うための設定
app.use(express.json())
app.use(express.urlencoded({ extended: true }));

// 環境変数を.envで管理するための設定
require('dotenv').config();

// mysqlへのコネクションを作成
const connection = mysql.createConnection({
    host: process.env.HOST,
    user: process.env.USER,
    password: process.env.PASSWORD,
    database: process.env.DATABASE,
});

// mysqlへ接続
connection.connect((err) => {
  if (err) {
    console.log('error connecting: ' + err.stack);
    return;
  }
  console.log('success');
});

// 設定したportで受け入れ
app.listen(port, () => {
  console.log(`Angular hero tutorial app listening at http://localhost:${port}`)
});

// ヒーローを取得
app.get("/api/heroes", (req, res) => {
    const sql = 'SELECT * FROM heroes';
    connection.query(sql, (err, result) => {
        if (err) throw err;
        const searchName = req.query?.name;
        // 名前で検索された場合は含まれるものを返す
        if (searchName) {
            const rec = result.filter(item => item.name.includes(searchName));
            res.json(rec);
            return;
        }
        // その他の場合はselectした結果をそのまま返す
        res.json(result);
    });
});

app.get("/api/heroes/:id", (req, res) => {
    const searchId = req.params.id;
    const sql = `SELECT * FROM heroes WHERE id = ${searchId}`;
    connection.query(sql, (err, result) => {
        if (err) throw err;
        const hero = result[0];
        res.json(hero);
    });
});

// ヒーローを更新
app.put("/api/heroes", (req, res) => {
    const updateId = req.body.id;
    const updateName = req.body.name;
    const sql = `UPDATE heroes SET name = '${updateName}' WHERE id = ${updateId}`;
    connection.query(sql, (err, result) => {
        if (err) throw err;
    });
});

// ヒーローを追加
app.post("/api/heroes", (req, res) => {
    const insertName = req.body.name;
    const sql = `INSERT INTO heroes(name) VALUES('${insertName}')`;
    connection.query(sql, (err, result) => {
        if (err) throw err;
        const insertId = result.insertId;
        const resHero = {id: insertId, name: insertName};
        res.json(resHero);
    });
});

// ヒーローを削除
app.delete("/api/heroes/:id", (req, res) => {
    const deleteId = req.params.id;
    const sql = `DELETE FROM heroes WHERE id = ${deleteId}`;
    connection.query(sql, (err, result) => {
        if (err) throw err;
    });
});
