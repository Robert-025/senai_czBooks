USE senai_czBooks;

-- Mostra todos os tipos de usuários
SELECT * FROM tiposUsuario;

-- Mostra todas as bibliotecas
SELECT * FROM biblioteca;

-- Mostra todas as categorias
SELECT * FROM categoria;

-- Mostra todos os usuários
SELECT * FROM usuario;

-- Mostra todos os autores
SELECT * FROM autor;

-- Mostra todos os livros
SELECT * FROM livro;

-- Mostra todos os livros depois de uma certa 
SELECT * FROM livro
WHERE dataPublicacao > '2010/01/01'

-- Simula um login
SELECT nome, email FROM usuario
WHERE email = 'neil@gmail.com' AND senha = 'n123';