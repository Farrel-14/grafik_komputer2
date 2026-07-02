📋 Panduan Instalasi & Penggunaan Program Grafik Warung Makan

🔧 Yang Dibutuhkan
SoftwareLink DownloadVisual Studio 2022/2026https://visualstudio.microsoft.com.
NET Framework 4.7.2+Sudah termasuk di Visual StudioGithttps://git-scm.com/downloads

! HARUS PUNYA GITBASH 

📥 Langkah 1 — Download Project dari GitHub
Buka Command Prompt, lalu jalankan:
bash

git clone https://github.com/Farrel-14/grafik_komputer2.git

Atau bisa juga lewat GitHub:

Buka https://github.com/Farrel-14/grafik_komputer2
Klik tombol hijau Code
Klik Download ZIP
Extract ZIP ke folder mana saja


📂 Langkah 2 — Buka Project di Visual Studio

Buka Visual Studio

Klik Open a project or solution

Cari folder grafik_komputer2

Pilih file grafik kaliiiiii.sln

Klik Open


📦 Langkah 3 — Install NuGet Package (OxyPlot)
Buka Tools → NuGet Package Manager → Package Manager Console, lalu jalankan:

Install-Package OxyPlot.WindowsForms

Tunggu sampai selesai hingga muncul tulisan Successfully installed.

▶️ Langkah 4 — Jalankan Program

Tekan Ctrl+Shift+B untuk Build
Pastikan tidak ada error di Error List
Tekan F5 untuk Run

Program akan muncul dengan tampilan 3 tab grafik:

📊 Bar Chart — Penjualan per bulan
📈 Line Chart — Tren keuangan
🥧 Pie Chart — Distribusi menu
