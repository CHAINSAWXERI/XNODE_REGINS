using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class CardNode : Node
{
    [Input] public string input; // Входной порт
    [Output] public string output; // Выходной порт

    public string cardText; // Текст карточки
    public int positiveEffect; // Положительный эффект
    public int negativeEffect; // Отрицательный эффект

    protected override void Init()
    {
        base.Init();
    }

    public override object GetValue(NodePort port)
    {
        if (port.IsOutput)
        {
            return cardText; // Возвращаем текст карточки при запросе
        }
        return null;
    }
}