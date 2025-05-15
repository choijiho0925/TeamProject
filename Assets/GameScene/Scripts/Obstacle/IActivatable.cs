using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{
    //스위치, 버튼으로 작동시킬 아이템들은 다 이거 IActivatable 인터페이스를 통해서 작동되게 통일시킬 예정입니다.
    //따라서 스위치, 버튼으로 작동시키고 싶은 아이템들은 각 오브젝트 스크립트에 IActivatable를 참조하게 만들어주세요.
    //각 오브젝트 스크립트에 Activate()에는 작동시킬 때 수행될 코드를
    //Deactivate()에는 버튼을 비활성화 시킬 때 수행될 코드를 넣으시면 됩니다.


    void Activate();
    void Deactivate();
}
