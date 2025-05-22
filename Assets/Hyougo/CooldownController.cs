using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    public float actionCooldown = 5f;      // �A�N�V������̃N�[���^�C���i�b�j
    private float actionEndTimePlayer1;    // �v���C���[1�̃N�[���^�C���I������
    private float actionEndTimePlayer2;    // �v���C���[2�̃N�[���^�C���I������

    // �v���C���[1�p�̐i���o�[�i�~�`�j
    public Image cooldownImagePlayer1;
    private bool isActioningPlayer1 = false;

    // �v���C���[2�p�̐i���o�[�i�~�`�j
    public Image cooldownImagePlayer2;
    private bool isActioningPlayer2 = false;

    private void Start()
    {
        // ������Ԃł͐i�����Ȃ���Ԃɐݒ�
        if (cooldownImagePlayer1 != null)
        {
            cooldownImagePlayer1.fillAmount = 0f;
        }
        if (cooldownImagePlayer2 != null)
        {
            cooldownImagePlayer2.fillAmount = 0f;
        }
    }

    private void Update()
    {
        HandlePlayerActions();
    }

    private void HandlePlayerActions()
    {
        // �v���C���[1���X�y�[�X�L�[�ŃA�N�V����
        if (Input.GetKeyDown(KeyCode.Space) && !isActioningPlayer1)
        {
            StartAction(ref isActioningPlayer1, ref actionEndTimePlayer1, cooldownImagePlayer1);
        }

        // �v���C���[2���E�V�t�g�L�[�ŃA�N�V����
        if (Input.GetKeyDown(KeyCode.RightShift) && !isActioningPlayer2)
        {
            StartAction(ref isActioningPlayer2, ref actionEndTimePlayer2, cooldownImagePlayer2);
        }

        // �v���C���[1�̃A�N�V������N�[���^�C�����Ǘ�
        if (isActioningPlayer1 && Time.time > actionEndTimePlayer1)
        {
            ResetCooldown(ref isActioningPlayer1, cooldownImagePlayer1);
        }

        // �v���C���[2�̃A�N�V������N�[���^�C�����Ǘ�
        if (isActioningPlayer2 && Time.time > actionEndTimePlayer2)
        {
            ResetCooldown(ref isActioningPlayer2, cooldownImagePlayer2);
        }

        // �A�N�V�����i���o�[�i�~�`�j�̍X�V
        UpdateCooldownUI();
    }

    // �A�N�V�������J�n���郁�\�b�h
    private void StartAction(ref bool isActioning, ref float actionEndTime, Image cooldownImage)
    {
        // �N�[���^�C���̏I��������ݒ�
        actionEndTime = Time.time + actionCooldown;
        isActioning = true;  // �A�N�V�����J�n
        cooldownImage.fillAmount = 1f;  // �i���o�[��100%�ɃZ�b�g
        Debug.Log("�A�N�V�����J�n�I");
    }

    // �A�N�V������̃N�[���^�C�������Z�b�g���郁�\�b�h
    private void ResetCooldown(ref bool isActioning, Image cooldownImage)
    {
        isActioning = false;  // �N�[���^�C���I��
        cooldownImage.fillAmount = 0f;  // �i���o�[�����Z�b�g
    }

    // �~�`�i���o�[��UI���X�V���郁�\�b�h
    private void UpdateCooldownUI()
    {
        // �v���C���[1�̃N�[���^�C���i���o�[�X�V
        if (isActioningPlayer1)
        {
            float remainingTime = actionEndTimePlayer1 - Time.time;  // �c�莞��
            cooldownImagePlayer1.fillAmount = remainingTime / actionCooldown;  // �c�莞�Ԃɉ����ăo�[�̐i���𒲐�
        }

        // �v���C���[2�̃N�[���^�C���i���o�[�X�V
        if (isActioningPlayer2)
        {
            float remainingTime = actionEndTimePlayer2 - Time.time;  // �c�莞��
            cooldownImagePlayer2.fillAmount = remainingTime / actionCooldown;  // �c�莞�Ԃɉ����ăo�[�̐i���𒲐�
        }
    }
}
