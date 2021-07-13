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
					 ('ação'),
					 ('terror');
GO

INSERT INTO biblioteca(cnpj, endereco, razaoSocial)
VALUES				  (12345678900, 'Alameda Barão de limeira, 538 - Santa Cecília, São Paulo, SP', 'CZBooks');
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
VALUES			 (1, 1, 1, 'Deuses Americanos', 'Deuses americanos é contada ao longo da jornada de Shadow Moon, um ex-presidiário de trinta e poucos anos que acabou de ser libertado e cujo único objetivo é voltar para casa e para a esposa, Laura. Os planos de Shadow se transformam em poeira quando ele descobre que Laura morreu em um acidente de carro. Sem lar, sem emprego e sem rumo, ele conhece Wednesday, um homem de olhar enigmático que está sempre com um sorriso no rosto, embora pareça nunca achar graça de nada.', '24/10/2016', '44.10'),
				 (2, 2, 1, 'A culpa é das estrelas', 'A culpa é das estrelas" narra o romance de dois adolescentes que se conhecem (e se apaixonam) em um Grupo de Apoio para Crianças com Câncer: Hazel, uma jovem de dezesseis anos que sobrevive graças a uma droga revolucionária que detém a metástase em seus pulmões, e Augustus Waters, de dezessete, ex-jogador de basquete que perdeu a perna para o osteosarcoma. Como Hazel, Gus é inteligente, tem ótimo senso de humor e gosta de brincar com os clichês do mundo do câncer - a principal arma dos dois para enfrentar a doença que lentamente drena a vida das pessoas. Inspirador, corajoso, irreverente e brutal, A culpa é das estrelas é a obra mais ambiciosa e emocionante de John Green, sobre a alegria e a tragédia que é viver e amar.', '13/05/2014', '24.90'),
				 (3, 3, 1,'O nome do vento', 'O nome do vento acompanha a trajetória de Kote e as duas forças que movem sua vida: o desejo de aprender o mistério por trás da arte de nomear as coisas e a necessidade de reunir informações sobre o Chandriano – os lendários demônios que assassinaram sua família no passado. Quando esses seres do mal reaparecem na cidade, um cronista suspeita de que o misterioso Kote seja o personagem principal de diversas histórias que rondam a região e decide aproximar-se dele para descobrir a verdade.', '27/03/2007', '49.90'),
				 (4, 4, 1, 'Jogos vorazes', 'A história se passa na nação chamada Panem, fundada após o fim da América do Norte. Formada por 12 distritos, é comandada com mão de ferro pela Capital, sede do governo. Uma das formas com que demonstra seu poder sobre o resto do carente país é com os Jogos Vorazes, uma competição anual transmitida ao vivo pela televisão, em que um garoto e uma garota de 12 a 18 anos de cada distrito são selecionados e obrigados a lutar até a morte. Para evitar que sua irmã seja a mais nova vítima do programa, Katniss se oferece para participar em seu lugar. Vinda do empobrecido Distrito 12, ela sabe como sobreviver em um ambiente hostil. Caso vença, terá fama e fortuna. Se perder, morre. Mas para ganhar a competição, será preciso muito mais do que habilidade. Até onde Katniss estará disposta a ir para ser vitoriosa nos Jogos Vorazes?', '20/08/2009', '35.73'),
				 (5, 5, 1, 'It: A coisa', 'Durante as férias de 1958, em uma pacata cidadezinha do Maine, Bill, Richie, Stan, Mike, Eddie, Ben e Beverly aprenderam o real sentido da amizade, do amor, da confiança… e do medo. O mais profundo e tenebroso medo. Naquele verão, eles enfrentaram pela primeira vez a Coisa, um ser sobrenatural e maligno que deixou terríveis marcas de sangue em Derry. Quase trinta anos depois, os amigos voltam a se encontrar. Uma nova onda de terror tomou a pequena cidade. Mike Hanlon, o único que permaneceu em Derry, dá o sinal. Precisam unir forças novamente. A Coisa volta a atacar e eles devem cumprir a promessa selada com sangue que fizeram quando crianças. Só eles têm a chave do enigma. Só eles sabem o que se esconde nas entranhas de Derry. O tempo é curto, mas somente eles podem vencer a Coisa. Neste clássico de Stephen King, os amigos irão até o fim, mesmo que isso signifique ultrapassar os próprios limites.', '15/09/1986', '59.90');
GO