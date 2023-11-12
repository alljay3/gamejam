using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogList2 : MonoBehaviour
{
    public static string[,] mother = {
        {"Привет..., у тебя все хорошо? ","Подожди, что с твоими глазами?", "Они красные!!!", "Скажи мне, что с тобой происходит? А?", "Не кричи на меня, что-бы больше я не видела тебя в таком состоянии"},
        {"Hi..., are you all right?","Wait, what's wrong with your eyes?","They're red!!!","Tell me what's going on with you? Eh?","Don't yell at me so I won't see you like this again"}
    };



    public static string[,] player = {
        {"Все хорошо мам, можно я пойду отдохну?" ,"С моими глазами?", "Я просто сильно устал мам, можно я пойду?", "Да все со мной впорядке, мам!", "Хорошо мам..."},
        {"It's okay Mom, can I go get some rest?","With my eyes?","I'm just really tired Mom, can I go?","It's all right with me, Mom!", "Okay, Mom..." }
    };
}
