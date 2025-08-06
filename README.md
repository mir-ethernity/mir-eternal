<h1 align="center">
Legend Eternal – Remake of Shanda Games' (now Shengqu Games) 2016 *Legend Eternal*
</h1>

[![AccountServer Build](https://github.com/Suprcode/mir-eternal/actions/workflows/accountserver-build.yml/badge.svg?branch=main)](https://github.com/Suprcode/mir-eternal/actions/workflows/accountserver-build.yml)
[![GameServer Build](https://github.com/Suprcode/mir-eternal/actions/workflows/gameserver-build.yml/badge.svg)](https://github.com/Suprcode/mir-eternal/actions/workflows/gameserver-build.yml)
[![Launcher Build](https://github.com/Suprcode/mir-eternal/actions/workflows/launcher-build.yml/badge.svg)](https://github.com/Suprcode/mir-eternal/actions/workflows/launcher-build.yml)

## Help us to continue maintaining the project
[![Donate with paypal](docs/paypal-donate-button.png)](https://www.paypal.com/donate/?hosted_button_id=SYTUMJ7742MRC)

### *If you have problems donating, try this other option*:
http://paypal.me/armifer

## Info

Originally, these sources were published on LOMCN in the following post:
https://www.lomcn.org/forum/threads/legend-of-mir-3d-emu-source-code.108580/

In this repository, we have done a refactoring, translation and correction work from the mentioned source.

## 🚀 Getting Started

### 🖥️ Client & Launcher Setup

1. Download a compatible client:

   - [**Latest Client**](https://mirfiles.co.uk/resources/mir2/users/Jev/Mir%203DEMU/Clients/CQYH1.0.4.14.7z)
   > ✅ Latest supported version: **v1.72 - 191186**

2. Copy the compiled launcher binaries into the client root folder.


3. Edit the `ServerCfg.txt` file in the launcher:

- If it is locally: `127.0.0.1:7000`
- If it is WAN: `<public_ip>:7000`

### 🔐 Account Server Setup

Create a file in the root of the Account Server directory named `Server.txt`.

Example configurations:

<details>
  <summary><strong>Localhost</strong></summary>

```txt
127.0.0.1,8701/ServerName 
```
</details>

<details>
  <summary><strong>Public/WAN</strong></summary>

```txt
88.888.888.88,8701/ServerName 
```
</details>

---

### 🎮 Game Server Setup

- Copy a valid system database into the `Database/System` folder.
- No further configuration is required for local use.
- For internet hosting, forward the following ports on your router:
  - **7000**
  - **8701**

---

## 🌐 Network Communication Diagram

![Mir Network](docs/mir-network.png)

---

## 🔗 Quick Links

### Official Resources

- 🌐 [Legend Eternal Website](https://cq.web.sdo.com/)
- 🌐 [Mir 3D Discord](https://discord.gg/sZX2nG5qDb)
  
### LOMCN Community

- 💬 [Development Section](https://www.lomcn.net/forum/forums/mir-3d-emulation.812/)
- 📚 [Tutorials](https://www.lomcn.net/forum/forums/mir-3d-tutorials.852/)
- 📦 [Releases](https://www.lomcn.net/forum/forums/mir-3d-releases.853/)
- 🐞 [Bug Reports](https://www.lomcn.net/forum/forums/mir-3d-bug-reports.813/)
- 🛠️ [Updates](https://www.lomcn.net/forum/forums/mir-3d-updates.814/)
- 📖 [Mir 3D EMU Wiki](https://www.lomcn.net/wiki/index.php/Mir3DEmu/)

---

## 🙏 Special Thanks

- [DontReallyMind](https://www.lomcn.net/forum/members/dontreallymind.4351/)
- [CraZyEriK](https://www.lomcn.net/forum/members/crazyerik.9944/)
- [Wincha](https://github.com/Wincha)
- [Lilcooldoode](https://www.lomcn.net/forum/members/lilcooldoode.940/)
- [Far](https://www.lomcn.net/forum/members/far.1046/)
- [Armifer (ElAmO)](https://www.lomcn.net/forum/members/elamo.10165/)
- [Damian (CodePwr)](https://www.lomcn.net/forum/members/damian.1126/)
- [Jev](https://www.lomcn.net/forum/members/jev.29880/)
- [mir2pion](https://www.lomcn.net/forum/members/mir2pion.19657/)
- [ByteNinja](https://www.lomcn.net/forum/members/qq7481006.42042/)

---

## <img src="https://mirfiles.co.uk/resources/mir2/users/Jev/favicon.png" width="20"> Other Projects

- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/mir1.png" alt="Mir1" width="20"/> [Mir 1](https://github.com/JevLOMCN/mir1/) | [Database](https://github.com/Suprcode/Carbon.Database) - Remake of ActozSoft's 1997 _The Legend Of Mir 1_
- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/mir2.png" alt="Mir2" width="20"/> [Mir 2](https://github.com/Suprcode/Crystal) | [Database](https://github.com/Suprcode/Crystal.Database) | [Map Editor](https://github.com/Suprcode/Crystal.MapEditor) - Remake of ActozSoft/Wemade Entertainment's 1999 _The Legend Of Mir 2_
- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/mir3.png" alt="Mir3" width="20"/> [Mir 3](https://github.com/Suprcode/Zircon) | [Database](https://mirfiles.com/resources/mir3/zircon/Database.7z) | [Map Editor](https://www.lomcn.net/forum/threads/map-editor.109317/)- Remake of Wemade Entertainment's 2003 _The Legend Of Mir 3_
- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/woool.png" alt="WoOOL" width="20"/> [WoOOL](https://www.lomcn.net/forum/forums/woool-development-project-onyx.857/) - Remake of Shanda Games' (now Shengqu Games) 2003 _The World Of Legend_
- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/mir3d.png" alt="Mir3D" width="20"/> [Mir 3D (Moon Spirit)](https://github.com/mir-ethernity/mir-eternal) | [Mir 3D (Hundred Cow)](https://github.com/JevLOMCN/Legend-Eternal-Mir3D) - Remake of Shanda Games' (now Shengqu Games) 2016 _Legend Eternal_
- <img src="https://github.com/JevLOMCN/mir4/blob/main/Tools/icons/mir4.png" alt="Mir4" width="20"/> [Mir 4](https://github.com/JevLOMCN/mir4) - Remake of Wemade Entertainment's 2021 _The Legend Of Mir 4_