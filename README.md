<div align="center">
<h1>Only One Chance 🎮</h1>
<a href="#">
  <img alt="image" src="./ReadMe_Image/Title.png">
</a>
  
<!--타이틀 잘라서 넣어주기-->

[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2FlIo0O0oIl%2F2022_1_Only_One_Chance&count_bg=%23EEEE0E&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)

</div> <!--가운데 정렬은 여기까지-->


## 목차
- [프로젝트 정보](#프로젝트-정보)
- [게임 설명](#게임-설명)
- [게임 다운](#게임-다운)
- [개발팀 소개](#개발팀-소개)
- [파일 구조](#파일-구조)


## 프로젝트 정보
- 제작 : 1학년 1학기 개인 수행평가  
- 기간 : 2022.05월경 ~ 2022.06.26


## 게임 설명
<div align="center">

|  InGame   |
| :-------: |
| <a href="#"> <img alt="image" width="250" src="./ReadMe_Image/InGame1.png"><img alt="image" width="250" src="./ReadMe_Image/InGame2.png"> </a> |

|   Intro   |   Outro   |
|:---------:|:---------:|
| <a href="#"> <img alt="image" width="250" src="./ReadMe_Image/Intro.png"> </a> | <a href="#"> <img alt="image" width="250" src="./ReadMe_Image/Outro.png"> </a> |

<!-- 영상이 있으면 이곳에 넣어주기
| video |
| :---: |
| <a href=""> <img alt="video" width="" src=""> </a> |
-->

|이동방향|위|왼쪽|아래|오른쪽|
|:---:|:---:|:---:|:---:|:---:|
|키보드| W | A | S | D |
|방향키|⬆️|⬅️|⬇️|➡️|

</div>

Only One Chance는 1학년 1학기 동안 배운 내용을 응용해서 약 1개월동안 만든 간단한 PC 슈팅게임입니다.  
플레이어 쪽으로 날라오는 적, 한 방향으로 내려오는 적이 랜덤으로 생성되며 3가지의 패턴을 가진 보스가 존재합니다.


## 게임 다운
구글 드라이브 : [https://drive.google.com/file/d/1hb1mr_L1kKyg1mslgdt7ng5TSz4dKZUp/view?usp=sharing]


## 개발팀 소개
<div align="center">

| <a href="https://github.com/lIo0O0oIl"> lIo0O0oIl </a> |
| :-----------: |
| <a href="https://github.com/lIo0O0oIl"> <img alt="image" width="200" src="https://github.com/lIo0O0oIl.png"> </a> |
| 1인 개발 |

</div>


## 파일 구조
<details>
<summary>눌러서 구조 보기</summary>
  
```bash
2022_1_ONLY_ONE_CHANCE\ASSETS
├─1_Scenes
│      GameClaer.unity
│      GameOver.unity
│      Intro.unity
│      Play.unity
│
├─2_Scripts
│  │  ButtonEvent.cs
│  │  Leave.cs
│  │  Leave.cs.meta
│  │
│  └─GamePlay
│          AutoDestroyer.cs
│          Boss.cs
│          BossBullet.cs
│          BossHP.cs
│          Bullet.cs
│          Bulletile.cs
│          Enemy.cs
│          EnemySpawner.cs
│          Enemytile.cs
│          Mana.cs
│          ManaViewer.cs
│          Movement.cs
│          Player.cs
│          PlayerHP.cs
│          PlayerHPViewer.cs
│          PlayerScoreViewer.cs
│          ResultScoreViewer.cs
│          StageData.asset
│          StageData.cs
│
├─3_Prefabs
│      BossBullet.prefab
│      Bullet.prefab
│      Enemy.prefab
│
├─4_Sounds
         Rinne - Connect.mp3
```

</details>


## 참고
#### 사용한 도구
<div align="left"> <a href="#">
  
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![Visual Studio 2023](https://img.shields.io/badge/Visual%20Studio%202022-5C2D91?style=for-the-badge&logo=Visual%20Studio&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=GitHub&logoColor=white)  
![Version](https://img.shields.io/badge/Unity_Version-2021.3.8f1-blue?style=flat-square)
</a> </div>
