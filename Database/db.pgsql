--
-- PostgreSQL database dump
--

-- Dumped from database version 11.1
-- Dumped by pg_dump version 11.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: admins; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.admins (
    reg_num character varying(6) NOT NULL
);


ALTER TABLE public.admins OWNER TO postgres;

--
-- Name: courses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.courses (
    id character varying(6) NOT NULL,
    name character varying(32) NOT NULL
);


ALTER TABLE public.courses OWNER TO postgres;

--
-- Name: professors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professors (
    reg_num character varying(6) NOT NULL
);


ALTER TABLE public.professors OWNER TO postgres;

--
-- Name: professorscourses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.professorscourses (
    prof_reg_num character varying(6) NOT NULL,
    course_id character varying(6) NOT NULL
);


ALTER TABLE public.professorscourses OWNER TO postgres;

--
-- Name: projectfiles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.projectfiles (
    id character varying NOT NULL,
    file bytea NOT NULL,
    name character varying(100) NOT NULL,
    date timestamp without time zone NOT NULL
);


ALTER TABLE public.projectfiles OWNER TO postgres;

--
-- Name: projects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.projects (
    id character varying(6) NOT NULL,
    name character varying(32) NOT NULL,
    description character varying(100) NOT NULL,
    max_grade integer NOT NULL,
    course_id character varying(6) NOT NULL,
    due_date timestamp without time zone NOT NULL
);


ALTER TABLE public.projects OWNER TO postgres;

--
-- Name: projectsofteam; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.projectsofteam (
    project_id character varying(6) NOT NULL,
    project_file_id character varying(6),
    team_id character varying(6) NOT NULL,
    grade integer
);


ALTER TABLE public.projectsofteam OWNER TO postgres;

--
-- Name: students; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.students (
    reg_num character varying(6) NOT NULL
);


ALTER TABLE public.students OWNER TO postgres;

--
-- Name: studentsteams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.studentsteams (
    stu_reg_num character varying(6) NOT NULL,
    team_id character varying(6) NOT NULL,
    course_id character varying(6) NOT NULL
);


ALTER TABLE public.studentsteams OWNER TO postgres;

--
-- Name: teams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teams (
    id character varying(6) NOT NULL
);


ALTER TABLE public.teams OWNER TO postgres;

--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    reg_num character varying(6) NOT NULL,
    name character varying(32) NOT NULL,
    password character varying(32) NOT NULL,
    surname character varying(32) NOT NULL,
    email character varying(40) NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Data for Name: admins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.admins (reg_num) FROM stdin;
\.


--
-- Data for Name: courses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.courses (id, name) FROM stdin;
C1	A.I.
C2	Analysi
C3	DBMS
C4	Computational_Biology
C5	Design_Patterns
C6	User_Experience
C7	Prolog
C8	C#
C9	C++
C10	Java
C11	Networks
C12	English
C13	Information_Systems
C14	Software_Technologies
C15	Logic_Design
C16	Cryptography
\.


--
-- Data for Name: professors; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.professors (reg_num) FROM stdin;
K00290
K11108
K11249
K10234
K11173
K13169
K15215
K10236
K14160
K13135
\.


--
-- Data for Name: professorscourses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.professorscourses (prof_reg_num, course_id) FROM stdin;
K00290	C1
K11108	C2
K11249	C3
K10234	C4
K11173	C5
K13169	C6
K15215	C7
K10236	C8
K14160	C9
K13135	C10
K00290	C11
K11108	C12
K11249	C13
K10234	C14
K11173	C15
K13169	C16
\.


--
-- Data for Name: projectfiles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.projectfiles (id, file, name, date) FROM stdin;
F1	\\x3031303031313131	sedSagittis.zip	2018-06-30 22:37:13.925001
F2	\\x3030313031313030	ac.zip	2018-06-30 22:37:13.925001
F4	\\x3131303031303130	lacusAt.zip	2018-06-30 22:37:13.925001
F5	\\x3030313030313131	platea.zip	2018-06-30 22:37:13.925001
F3	\\x504b0304140000000800ed76de4e0538625c580d0000473500000c00000065636c6173732e706773716ccd5b6b6fdbb812fdcc02fd0f42ef876eb18ea1879f292e6047b1db348ef37292f66201839668993145a99414c7f9f577483d2c274eeaec3a8bb6684949e4cc9c33c3218769f7f6debfdbdbd3ce8228f604b93c1f682e8ef104474473133f941fdfbf53430ee191b8da5404fe6acc1d11110db8661855a33c6ab2d4426f2c253c1af2fedd656fa445318e894f783c8ea94f8224d6feabe99fd36f2c70e61b5e53979131e5e358601e61270691e3884452f486d10ea3523ae14ee052eec1978f57a37eebe3e7423f77b170c74ec0a781f061c8388a0534110c0db81a36e8d92389c201b02cf0aa1189d578eafdf131225838b37188e3d9c78af611fe4c318bc8a75cfd8c008869c2533b27814b8994ac06ad9b08bac73ee0c09e1ab1c0828319d918112c00a493081a2fa561d3e9e79c42974c71c280403c61240ab14324c88f4fbe2f683c1b07d42dab979e52de1a629fec6bd80523a2cfda6819c2d3a87b30e87dd62e01838ff7b5309930ea7cd64e179c08784c0325ca03c3bee87547bd745236b69acad3fe78ff4e835f8278639ef8c00916e03722b43b2c9680f18fc6276d783ad2865783c1fb779f945defdf7507a3dec54679a73743f9e5b4b0e1291227484444760825139863a1eecb302ae9300ec66c1868995b02ceb56e813814c114a227103b04bd92b93b1f9664be0ad5ce3dfa44748e517e186f0534f3723a7f4cdd9dd0f23a9fdf12279e52b663620aa92fc5fb631ae404c8f731c1db2e03fd0995b09f104d667148ccb065c89c25f3b97ca33d049c6c4de60ac1f63cee9ec337c81739512472040de5aeb26182a13fa5d6c7f7634f60976894c7c423e26f86716e4042c63bf5d6ab3c154c21ccfcddfb2b959b7b2d7bbb2d25f9701977cfcdc9864a2ddb8a5d73da564c6628b6e0338a1397f05d467e2e71773b4621f1157824fe3700a5c4e6c8e0e5abb689d7f87c175bcabad15b90b763d2d6c8fa4748b64690446497e71f25ee55815ccae3dbe5f11047d12210ee76a3a3446c2f1a5053b661684ddf92f614fe8bb41f4249a441e1f47c01a11d7647ddedbd707af6e371f59011ff49eb5f9c9ec0aa833a0e4cf8abfafeddf386a4eb675796140744ea56946f1fd9621ba85b3d02836c13753966cb8842df4287072797d0a9213bf0c324c672b7c66c7c4003282397f0a58e0e49443d3e3ec331b8888376bb81ae80f771ef3e24020a4387c0bb263a13720e745bc8fe0f346d64fff9a7d4aca36ff80ecb9e8186245e04622ea51826ea718fd168261f2c74a4ca5b65c1f8720939c157a36ae812360ba835c978449c19974a28519fea68007d679c5a28df34902d96611cc08614ce96bf72c1ea44bb232fac043e1713c7ba6eb675680dc3d05baa356b6dd9eaa6554bdf372dd95a4643bdaf9b463dfbde906dcd68e8e977abbe3dc0dd46db86c2a45c9254569bc346f8c8367206906de62420dbca7940764105b2eb391bc86ee48420bb997382ec564e0bb2db3933a0422fa92be9334a0a8d9246a3a4d228e9341a5bb05c9ce577477021325dd3b29baeec8a2a411e11db37d05f7fdd5b3a60d7d5dfea378a887b893d1ac734aa3ed01099bad1dad39b7b86ae19c67ebdb65f07c6fa6636379d6da4321076f229ed3dbdbea7b734c3da378d7d1dc8ec5b6a8a51fc56935144e3ae4f621b9c9f94141afa9ed9d08cd67ebd0d3a6176ad98bd52aa23869d24eac625add69e59975aadd6be010eefd7d70ccd60a290011fb8a4ced8336b9adedcb7da60ef96dedbb1e74a99b852ae842aab22a7b44a2a45adf2c8ad6706ca041ae8042782461a70ac81d458232288aaa8212337a50b701b405773bfd6dc3781ae33339f6ca233c2189cb448f433211a8e359e3086abc8906b209badcbd9a65eccb6f2d916ea32fa33c1fe4ab74be1897200e371ac4de88470170e1ed4871dc1a524aea256c9aec7926bb9e41a3a09c4846a11f1355fc1ab680c0782808a24ae6862167088090d4bfd045e8409bba31c0b9821d9a511ab2299229e5154cf15d5d12571b53bc234c26909074fb8a3ddd13b2204866515d209c42d826c603e23b1914b6ca06ba829613c03dc1898d56818413714d4a791e4668a1347cad302e1508d254e0c7d096c4219c51a2c124c3e6be055492db802f254eb19adcd5c6b131d65957141890fc7332c0faf2c980402163a8415c78e93f811e67060662c89245354238932a58adacfe36be59a5ae810ca6347ba067caa45c00de11ad618f85a048aa36723a79d0b69a37e1239445ae425a492858d0b66800fc92a5c2ab97c7978040a494c135fb9b70271a0dd054ab77012e9770d2720ac8a4c64378bfcb26e80a117cb46474319eae00d07688f684ab451df3c73bb549116af3b4e18795dbfaae82b8fcbf54a5ea055d28afb71b26820c890a31a6aabc4015bc2c842865ac990af477594ae3d48f72353bd6f21c8c42303d57e053cafd376043917f7dc21e9c4802dde4adb9a6a6b66dd485bbd2ddb7ab3aeabd668d555db6a99aab5f45a362f7d6e582df56c36d538ab5d6fa6efdbea596e21aa355a6a9c554be75b8d5a3b7db6d2f13553b552d10b64fda2c0ffe78c65056ba9ae2fc544b19d6ca4533adacec9b16408d8cd9c5a1928763d275886906de634cbc0b1cd9cec951449f94a8a247e2545d25f92024e584991ae5849910e294901b7aca448e7aca44817ada4484795a480bb5652a4d35652a4eb56528cfa4acacb6edca5fb32b73df1cc08827a04968c2008478064f4cb13bd2a7877645576775004527a58c9cbfd4a5eca57d2327d7350753d74f72388e6c3d3ebb3f39f13740087b839660ce149d6d33bd4772750a0fa45ec7d59104ea09a44b7b7c943f7ec61708346b075212f86bf8d8e03c6cd2798cfab30aa08d1632c28466d97b50f93a18d4633d844c8040b112cd03c2e3d999d18a820c0196cd02b1110d73f40294649dbf9be341b77df2fe7b7200610466819abd6ea809911e10fb9b96a01f4d8827274ed8ffacde336412794310f8e6a88f859afd6c1ae1bcf68544c932be50b9d4eb170d1b2f1b5fe7d72d373ee1b17c8c6cc2572a1025aa7e8d73b4bc2c262b65c595d97308cce5b0fdfefa2077440c41c03a7b2697468142549315aaebc43cc09baba39b770f8f5fe189d018102767ee48659afd99191003b7712955c61a203413959a21b7a9c9cb6af291a8207660447319af0bcdbeadc0b820b7d7235db702e033229c7e862162722b1d04500b50a72846cda1d7917ccf2296ac977b90be73a744ec5ececa189bac944e025c258b5b8e3622fe0ae2ae4f3692a379cc041070e38c83e9ab2e4811d39e818879405d329f2e7596fd2b99b073cc6f39854455224924b3a5932c45ac71609d16019cfbc80a088a51da713cd82700f76d8ea6d58649b2f18c248207e7a46eeaffb7597f56ed3909e416a05974d8abedb21b360919baa92137029e3ebbbb168986c8e2e6338df4401479328eb914e1c840027ae3a0f4512eb63ee2c11699df5dceecce21e453ddf27101f53a2da69c70b028f916ac88a54774d8447d08567dd5f1df4e8e1cd0d781cc813e82e54add7912b36e342a5c3c380b1250acf97cd21b6ae97a7e802f3a58c4e57a49d194455d5738b8cd913648ecc2f37f3616d510f0e2845b6487c1f2c75544b3b1316785118c439072ab5da98c60c56cb4ddf18f2db1fba737582ae038f30022f9dbbac77db9966d3b20abdc764ce8967483f6147ee62611ca06f54e008915bd9e81d8e235cf582bba28eff02d488c4c5c8a3d3abe668723c37d94f348068461e18408cce120369c44d8a72ff04dfc3d95cfe530614cca31677068d1eff6aa36f98fb9823ff56b566ce37d8579dcd8b0b8263a84ee22547337f3aec1f4557757448b58bc4f328ac2a3477a9c8fa5627c22cc8a238bb513881ec82c4ede2e72cf60e96df440f1d261c4cf55dd9d43a04037846f39497dd3d0c711c2f9169f27e2b99cfe7ff03d401732544eea59d7ac7e18526753132c0895cef181cfcf5e1e8f20add10583f882d6403a983c379db0bbc209fa4ae500604738ecedb49526f7f9b78a7e82a9a11b1080217b124ef36213107893b657074cf67ab5b9703c81114085cce1eae2e0e0613402be4f3c4576dab33c1dc75b01fe6b3d405cda1200bd43eee4e07dfce5b31ea134836b0ae60bdb8d3a2dfeec8ca79e2a6331f6d8d6bf7a89a9d9e7ec279be3bdaa7c3cbd145f76838da7a772cdf309f0e078f6f57d34bebeee16149b6f6a150fc413bbb383ae95efcd08e7b3fd46eff7983bd6b573b67e9439fb237b2bcac6db3f9eb26bc0a4361ff9bdafeb2dd5bdb9c9ec146f2b0fc26d62af99b4dcd946e67677a2a5317ec6f62a792bfd9ce4ce9233bb3f3e14663b31f80a44d5e928ce764b923c3cb86a74a365afe54bf76353c3abfeabd6cfdea1abbd47d63142b451b91ac3ebf1a4d5e23169d374692abd98823fff84f7c729677c7d3b99e03e81fff8bdef8b066c207ad7f7ad13bfa325c5f17da45afdfbbe80deddee5da1adb7ae1bc1dbc5f2d19a97987a09efe58e8c99b7fc3952fedd64f463da5a0fc93ac4d3cac44ec800ce37723c35827a374a7f494896cd6733bd9a39bcdec317d7ad33828697d0ef7ba25eb985737b09b40e7f2ff266ae3b7416d6c462d8f8a2f439723fe2e7cf3b7816faec3576f37c35627bb5fe12d3a6f1fd92fc153ea77b7841f9f29de0edc36a7891d6f57eb97eae5a7b787f97cb5501ef11470e9e67f13e87cf2dfc76dfc26b88ddd2ccf17b19abf095673170bf6b9ff16a539811f321293dcecff03504b01021f00140000000800ed76de4e0538625c580d0000473500000c002400000000000000200000000000000065636c6173732e706773716c0a00200000000000010018001de56eb53a2fd5015d6121b53a2fd5015d6121b53a2fd501504b050600000000010001005e000000820d00000000	eclass.zip	2019-07-01 02:40:10.5358
\.


--
-- Data for Name: projects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.projects (id, name, description, max_grade, course_id, due_date) FROM stdin;
P1	project1	Mauris sit amet eros.	6	C14	2019-10-15 20:47:27
P2	project2	Pellentesque at nulla.	1	C13	2019-10-15 20:47:27
P3	project3	Aliquam sit amet diam in magna bibendum imperdiet.	8	C14	2019-10-15 20:47:27
P4	project4	Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl.	3	C5	2019-10-15 20:47:27
P5	project5	Sed vel enim sit amet nunc viverra dapibus.	4	C2	2019-10-15 20:47:27
P6	project6	Vestibulum ante ipsum primis in faucibus orci luctus et ubilia Curae; Mauquam.	10	C8	2019-10-15 20:47:27
P7	project7	Integer aliquet, massa id lobortis conaccumsan tellus nisi eu orci.	9	C2	2019-10-15 20:47:27
P8	project8	Donec semper sapien a libero.	4	C13	2019-10-15 20:47:27
P9	project9	Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut voien arcu sed augue.	2	C7	2019-10-15 20:47:27
P10	project10	Nulla facilisi.	10	C15	2019-10-15 20:47:27
P12	sda	dsadasdasdadsa	2	C2	2019-10-15 20:47:27
P11	test	sadasds	4	C2	2019-01-15 20:47:27
\.


--
-- Data for Name: projectsofteam; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.projectsofteam (project_id, project_file_id, team_id, grade) FROM stdin;
P6	F5	T4	9
P1	F1	T3	1
P4	F2	T2	1
P8	F4	T1	4
P11	\N	T4	\N
P11	\N	T5	\N
P1	\N	T6	\N
P3	\N	T6	\N
P3	F3	T5	4
\.


--
-- Data for Name: students; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.students (reg_num) FROM stdin;
M12153
M12143
M14251
M14209
M15750
M15185
M15882
M15304
M12142
M15638
M12275
M13957
M15695
M10313
M10188
M13404
M13649
M13437
M15427
M11588
\.


--
-- Data for Name: studentsteams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.studentsteams (stu_reg_num, team_id, course_id) FROM stdin;
M12153	T1	C13
M15185	T1	C13
M12275	T1	C13
M13404	T1	C13
M12143	T2	C5
M15882	T2	C5
M13957	T2	C5
M13649	T2	C5
M14251	T3	C14
M15304	T3	C14
M15695	T3	C14
M13437	T3	C14
M15750	T5	C14
M15638	T5	C14
M10188	T5	C14
M11588	T5	C14
\.


--
-- Data for Name: teams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teams (id) FROM stdin;
T1
T2
T3
T4
T5
T6
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (reg_num, name, password, surname, email) FROM stdin;
M12153	Ag	vYoskNOVPQqb	Blackall	ablackall0@imdb.com
M12143	Gwenette	jjuzAPzLW	Tort	gtort1@clickbank.net
M14251	Karia	9dl9DuNC	Thornebarrow	kthornebarrow2@themeforest.net
M14209	Yetta	u9cXy26vXSkj	Thames	ythames3@comsenz.com
M15750	Elwin	VmTF7K9e	Millgate	emillgate4@addthis.com
M15185	Giffard	y6H5XbWEcx6R	Caldecourt	gcaldecourt5@yelp.com
M15882	Adela	Q8zXvsz	Berka	aberka6@issuu.com
M15304	Dane	UWQ3apHxK	Pickrell	dpickrell7@posterous.com
M12142	Briney	WiKuO9Vi	Northeast	bnortheast8@xrea.com
M15638	Concettina	Rhturu3	Roles	croles9@intel.com
M12275	Andree	QirhPz7	Aubray	aaubraya@dagondesign.com
M13957	Malissa	CIfluzlIc	Kapiloff	mkapiloffb@vkontakte.ru
M15695	Sibyl	l8K3ep	Lythgoe	slythgoec@shop-pro.jp
M10313	Garner	nOPexVF5dlEj	Blackhurst	gblackhurstd@ehow.com
M10188	Britta	X1w62lk	Stimpson	bstimpsone@toplist.cz
M13404	Fancy	e8PEdAh3ngi	Emmert	femmertf@google.pl
M13649	Verge	Rg3xUBEiDWW	Pinder	vpinderg@mail.ru
M13437	Dolly	pQy7Na3VyO	Ranyard	dranyardh@is.gd
M15427	Erek	2GWkN4w5oBii	Crummy	ecrummyi@blogspot.com
M11588	Caitlin	WF1NnjY0cUM	Vogelein	cvogeleinj@ft.com
K00290	Elsworth	0MlIdww1B	Jiras	ejiras0@nasa.gov
K11108	Gertruda	gifU7TbKk2lq	Line	gline1@yale.edu
K11249	Maximilien	oks8ncL6EnHC	Janman	mjanman2@google.com.hk
K10234	Kristyn	hmfNFIsU5	Di Ruggiero	kdiruggiero3@salon.com
K11173	Mame	rjwqhtgByJrE	Dunne	mdunne4@earthlink.net
K13169	Natty	22nF8ukkkZ8	Goldine	ngoldine5@cnn.com
K15215	Laurella	RaHzISU	Weiss	lweiss6@indiegogo.com
K10236	Leann	Q9uu59JbgO	Usherwood	lusherwood7@cloudflare.com
K14160	Bastian	yhzURBLb	Marian	bmarian8@bandcamp.com
K13135	Drew	9KAfLJQ8t	Fetherston	dfetherston9@scribd.com
\.


--
-- Name: courses Course_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.courses
    ADD CONSTRAINT "Course_pk" PRIMARY KEY (id);


--
-- Name: projectfiles ProjectFile_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projectfiles
    ADD CONSTRAINT "ProjectFile_pk" PRIMARY KEY (id);


--
-- Name: projects Project_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projects
    ADD CONSTRAINT "Project_pk" PRIMARY KEY (id);


--
-- Name: teams Team_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teams
    ADD CONSTRAINT "Team_pk" PRIMARY KEY (id);


--
-- Name: users User_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "User_pk" PRIMARY KEY (reg_num);


--
-- Name: admins admins_reg_num_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admins
    ADD CONSTRAINT admins_reg_num_key UNIQUE (reg_num);


--
-- Name: professors professors_reg_num_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professors
    ADD CONSTRAINT professors_reg_num_key UNIQUE (reg_num);


--
-- Name: students students_reg_num_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_reg_num_key UNIQUE (reg_num);


--
-- Name: professors Professor_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professors
    ADD CONSTRAINT "Professor_fk0" FOREIGN KEY (reg_num) REFERENCES public.users(reg_num);


--
-- Name: admins admin_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.admins
    ADD CONSTRAINT admin_fk0 FOREIGN KEY (reg_num) REFERENCES public.users(reg_num);


--
-- Name: professorscourses professorscourses_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professorscourses
    ADD CONSTRAINT professorscourses_fk0 FOREIGN KEY (prof_reg_num) REFERENCES public.professors(reg_num);


--
-- Name: professorscourses professorscourses_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.professorscourses
    ADD CONSTRAINT professorscourses_fk1 FOREIGN KEY (course_id) REFERENCES public.courses(id);


--
-- Name: projectsofteam projectofteam_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projectsofteam
    ADD CONSTRAINT projectofteam_fk0 FOREIGN KEY (project_id) REFERENCES public.projects(id);


--
-- Name: projectsofteam projectofteam_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projectsofteam
    ADD CONSTRAINT projectofteam_fk1 FOREIGN KEY (project_file_id) REFERENCES public.projectfiles(id);


--
-- Name: projectsofteam projectofteam_fk2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projectsofteam
    ADD CONSTRAINT projectofteam_fk2 FOREIGN KEY (team_id) REFERENCES public.teams(id);


--
-- Name: projects projects_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.projects
    ADD CONSTRAINT projects_fk0 FOREIGN KEY (course_id) REFERENCES public.courses(id);


--
-- Name: students student_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.students
    ADD CONSTRAINT student_fk0 FOREIGN KEY (reg_num) REFERENCES public.users(reg_num);


--
-- Name: studentsteams studentsteam_fk0; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studentsteams
    ADD CONSTRAINT studentsteam_fk0 FOREIGN KEY (stu_reg_num) REFERENCES public.students(reg_num);


--
-- Name: studentsteams studentsteam_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studentsteams
    ADD CONSTRAINT studentsteam_fk1 FOREIGN KEY (team_id) REFERENCES public.teams(id);


--
-- Name: studentsteams studentsteam_fk2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studentsteams
    ADD CONSTRAINT studentsteam_fk2 FOREIGN KEY (course_id) REFERENCES public.courses(id);


--
-- PostgreSQL database dump complete
--

