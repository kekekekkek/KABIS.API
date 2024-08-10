document.getElementById("top").addEventListener("click", function() {
    window.scroll(0, 0);
});

document.getElementById("github").addEventListener("click", function() {
    window.open("https://github.com/kekekekkek/KABIS.API", "_blank");
});

document.getElementById("discord").addEventListener("click", function() {
    window.open("https://discordapp.com/users/428279123526549506", "_blank");
});

for (let i = 0; i < document.getElementsByClassName("btn-copy").length; i++)
{
    document.getElementsByClassName("btn-copy")[i].addEventListener("click", function() {
        this.value = "✔️";
        this.className = "btn-copied";

        var strValue = document.getElementsByClassName("code-section cancopy")[i].innerText.replace("C# - Пример импорта\n\n", "");    
        (strValue.indexOf("C# - Пример кода") != -1 ? strValue = strValue.replace("C# - Пример кода\n\n", "") : strValue = strValue.slice(0, (strValue.length - 1)));

        navigator.clipboard.writeText(strValue);
        setTimeout(() => {
            this.value = "🗐";
            this.className = "btn-copy";
        }, 2000);
    });
}