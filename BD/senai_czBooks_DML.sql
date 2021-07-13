USE senai_czBooks;

INSERT INTO tiposUsuario(tipo)
VALUES					('administrador'),
						('autor'),
						('cliente');
GO

INSERT INTO categoria(categoria)
VALUES				 ('mitologia'),
					 ('romance'),
					 ('fantasia'),
					 ('a��o'),
					 ('terror');
GO

INSERT INTO biblioteca(cnpj, endereco, razaoSocial)
VALUES				  (12345678900, 'Alameda Bar�o de limeira, 538 - Santa Cec�lia, S�o Paulo, SP', 'CZBooks');
GO

INSERT INTO usuario(idTipoUsuario, nome, email, senha)
VALUES			   (1, 'Saulo', 'adm@adm.com', 'adm123'),
				   (2, 'Caique', 'caique@gmail.com', 'c123'),
				   (3, 'Neil', 'neil@gmail.com', 'n123'),
				   (3, 'John', 'john@hotmail.com', 'j123'),
				   (3, 'Patrick', 'patrick@gmail.com', 'p123'),
				   (3, 'Suzanne', 'suzanne@hotmail.com', 's123'),
				   (3, 'Stephen', 'stephen@gmail.com', 'sk123');
GO

INSERT INTO autor(idUsuario, sobrenome)
VALUES			 (3, 'Gaiman'),
				 (4, 'Green'),
				 (5, 'Rothfuss'),
				 (6, 'Collins'),
				 (7, 'King');
GO

INSERT INTO livro(idCategoria, idAutor, idBiblioteca, titulo, sinopse, dataPublicacao, preco)
VALUES			 (1, 1, 1, 'Deuses Americanos', 'Deuses americanos � contada ao longo da jornada de Shadow Moon, um ex-presidi�rio de trinta e poucos anos que acabou de ser libertado e cujo �nico objetivo � voltar para casa e para a esposa, Laura. Os planos de Shadow se transformam em poeira quando ele descobre que Laura morreu em um acidente de carro. Sem lar, sem emprego e sem rumo, ele conhece Wednesday, um homem de olhar enigm�tico que est� sempre com um sorriso no rosto, embora pare�a nunca achar gra�a de nada.', '24/10/2016', '44.10'),
				 (2, 2, 1, 'A culpa � das estrelas', 'A culpa � das estrelas" narra o romance de dois adolescentes que se conhecem (e se apaixonam) em um Grupo de Apoio para Crian�as com C�ncer: Hazel, uma jovem de dezesseis anos que sobrevive gra�as a uma droga revolucion�ria que det�m a met�stase em seus pulm�es, e Augustus Waters, de dezessete, ex-jogador de basquete que perdeu a perna para o osteosarcoma. Como Hazel, Gus � inteligente, tem �timo senso de humor e gosta de brincar com os clich�s do mundo do c�ncer - a principal arma dos dois para enfrentar a doen�a que lentamente drena a vida das pessoas. Inspirador, corajoso, irreverente e brutal, A culpa � das estrelas � a obra mais ambiciosa e emocionante de John Green, sobre a alegria e a trag�dia que � viver e amar.', '13/05/2014', '24.90'),
				 (3, 3, 1,'O nome do vento', 'O nome do vento acompanha a trajet�ria de Kote e as duas for�as que movem sua vida: o desejo de aprender o mist�rio por tr�s da arte de nomear as coisas e a necessidade de reunir informa��es sobre o Chandriano � os lend�rios dem�nios que assassinaram sua fam�lia no passado. Quando esses seres do mal reaparecem na cidade, um cronista suspeita de que o misterioso Kote seja o personagem principal de diversas hist�rias que rondam a regi�o e decide aproximar-se dele para descobrir a verdade.', '27/03/2007', '49.90'),
				 (4, 4, 1, 'Jogos vorazes', 'A hist�ria se passa na na��o chamada Panem, fundada ap�s o fim da Am�rica do Norte. Formada por 12 distritos, � comandada com m�o de ferro pela Capital, sede do governo. Uma das formas com que demonstra seu poder sobre o resto do carente pa�s � com os Jogos Vorazes, uma competi��o anual transmitida ao vivo pela televis�o, em que um garoto e uma garota de 12 a 18 anos de cada distrito s�o selecionados e obrigados a lutar at� a morte. Para evitar que sua irm� seja a mais nova v�tima do programa, Katniss se oferece para participar em seu lugar. Vinda do empobrecido Distrito 12, ela sabe como sobreviver em um ambiente hostil. Caso ven�a, ter� fama e fortuna. Se perder, morre. Mas para ganhar a competi��o, ser� preciso muito mais do que habilidade. At� onde Katniss estar� disposta a ir para ser vitoriosa nos Jogos Vorazes?', '20/08/2009', '35.73'),
				 (5, 5, 1, 'It: A coisa', 'Durante as f�rias de 1958, em uma pacata cidadezinha do Maine, Bill, Richie, Stan, Mike, Eddie, Ben e Beverly aprenderam o real sentido da amizade, do amor, da confian�a� e do medo. O mais profundo e tenebroso medo. Naquele ver�o, eles enfrentaram pela primeira vez a Coisa, um ser sobrenatural e maligno que deixou terr�veis marcas de sangue em Derry. Quase trinta anos depois, os amigos voltam a se encontrar. Uma nova onda de terror tomou a pequena cidade. Mike Hanlon, o �nico que permaneceu em Derry, d� o sinal. Precisam unir for�as novamente. A Coisa volta a atacar e eles devem cumprir a promessa selada com sangue que fizeram quando crian�as. S� eles t�m a chave do enigma. S� eles sabem o que se esconde nas entranhas de Derry. O tempo � curto, mas somente eles podem vencer a Coisa. Neste cl�ssico de Stephen King, os amigos ir�o at� o fim, mesmo que isso signifique ultrapassar os pr�prios limites.', '15/09/1986', '59.90');
GO