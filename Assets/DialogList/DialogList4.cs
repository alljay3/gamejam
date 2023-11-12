using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogList4 : MonoBehaviour
{
    public static string[,] mother = {
        {"...", "Я... Нашла у тебя под краватью мешочек с белым порошком", "Я просто хотела постирать твои брюки, а это вывалилось, о господи... ты и правда это употребляешь? Скажи что это не так, пожалуйста...","Хотела бы я поверить тебе..."},
        {"...", "I... found a bag of white powder under your bed", "I just wanted to wash your pants, and this fell out, oh my God... do you really use it? Tell me it's not like that, please...", "I wish I could believe you..."}
    };



    public static string[,] player = {
        {"Привет мам, что с тобой? Почему ты плачешь?" ,"Эй, может ответишь мне, что происходит?", "Что, зачем ты лазела в моих вещах?", "Мам, успокойся, я брошу эту дрянь, обещаю... Только не плачь прошу"},
        {"Hi Mom, what's wrong with you? Why are you crying?","Hey, can you tell me what's going on?","What, why did you go through my stuff?","Mom, calm down, I'll quit this stuff, I promise... Just don't cry please"}
    };
}
