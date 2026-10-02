using UnityEngine;
using UnityEngine.InputSystem;

enum WeaponType
{
    Knife = 0,
    Primary = 1,
    Sidearm = 2,
}

public class WeaponsParameter : MonoBehaviour
{
    [SerializeField] private InputActionReference _fireAction;
    [SerializeField] WeaponType _weapon;
    [SerializeField] bool _isFire;
    [SerializeField] bool _coolTime;
    [SerializeField] bool _isPressFire;
    [SerializeField] bool _fireSwitch;
    [SerializeField] float _coolDown;
    [SerializeField] float _nowtime;

    private void Awake()
    {
        if (_fireAction == null) return;
        _fireAction.action.performed += FireGun;
        _fireAction.action.Enable();
    }

    void Start()
    {
        _weapon = 0;
        _isFire = true;
    }

    void FixedUpdate()
    {
        _isPressFire = _fireAction.action.IsPressed();

        if (_fireSwitch)
        {
            if (_coolTime && !_isFire)
            {
                if (_nowtime < _coolDown)
                {
                    _nowtime += Time.deltaTime;
                }
                else
                {
                    _nowtime = 0;
                    _isFire = true;
                }
            }
            if (_isFire && _isPressFire)
            {
                if (_weapon != WeaponType.Knife)
                {
                    Debug.Log("弾消費");
                }
                else
                {
                    Debug.Log("ナイフ使用中");
                }

                _coolTime = true;
                _isFire = false;
            }
        }
    }

    private void FireGun(InputAction.CallbackContext context)
    {
        _fireSwitch = true;
    }
}
