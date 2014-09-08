using UnityEngine;
using System.Collections;

public class MultiMachineGun : BaseWeapon {

	public GameObject[] m_MachineGuns = null;
	protected int numberOfGuns;
	protected GameObject m_CurrentGun = null;
	protected int m_CurrentGunIndex = 0;

	public void Start()
	{
		numberOfGuns = m_MachineGuns.Length;
		m_CurrentGun = m_MachineGuns[0];

		for( int i = 0; i < numberOfGuns; i++)
		{
			m_MachineGuns[i].GetComponent<MachineGun>().m_FiringDelay = 0;
		}
	}

	protected override void Fire ()
	{
		m_CurrentGun.GetComponent<MachineGun>().handleClick();
		swapCurrentGun();
	}

	private void swapCurrentGun()
	{
		if( m_CurrentGunIndex + 1 >= numberOfGuns)
		{
			m_CurrentGunIndex = 0;
		}
		else
		{
			m_CurrentGunIndex += 1;
		}

		m_CurrentGun = m_MachineGuns[m_CurrentGunIndex];
	}
}
