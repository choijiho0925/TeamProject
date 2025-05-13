using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{
    //����ġ, ��ư���� �۵���ų �����۵��� �� �̰� IActivatable �������̽��� ���ؼ� �۵��ǰ� ���Ͻ�ų �����Դϴ�.
    //���� ����ġ, ��ư���� �۵���Ű�� ���� �����۵��� �� ������Ʈ ��ũ��Ʈ�� IActivatable�� �����ϰ� ������ּ���.
    //�� ������Ʈ ��ũ��Ʈ�� Activate()���� �۵���ų �� ����� �ڵ带
    //Deactivate()���� ��ư�� ��Ȱ��ȭ ��ų �� ����� �ڵ带 �����ø� �˴ϴ�.


    void Activate();
    void Deactivate();
}
