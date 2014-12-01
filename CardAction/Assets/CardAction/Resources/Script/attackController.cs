using UnityEngine;
using System.Collections;

public class attckContoller {
	private static attckContoller mInstance;
	Player pPlayer;
	//enemy[] pEnemy;
	private attckContoller () { // Private Constructor
		
		Debug.Log("Create SampleSingleton GameObject instance.");
	}
	
	public static attckContoller Instance {
		
		get {
			if( mInstance == null ) {
				mInstance = new attckContoller();
				mInstance.Start();
			}
			
			return mInstance;
		}
	}

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("Player");
		pPlayer = obj.GetComponent<Player>();
	}

	public void AttckJudge(int id){
		if (pPlayer.rigor <= 0) {
            //エフェクト
            GameObject effect = (GameObject)Resources.Load<GameObject>("prefab/Type02");
            Object.Instantiate(effect, pPlayer.transform.position, Quaternion.identity);
						GameManager GM = GameManager.Instance;
						CardData CD = GM.GetCard (id);
						switch (CD.type) {
						case CardData.TYPE.SORD:
								switch (CD.id) {
								case 0:
									pPlayer.rigor = CD.rigor;
									sordRange (CD);
									break;
								case 1:
									pPlayer.rigor = CD.rigor;
									longSordRange(CD);
									break;
								case 2:
									pPlayer.rigor = CD.rigor;
									wideSordRange(CD);
									break;
								}
								break;
						case CardData.TYPE.BULLET:
								switch (CD.id) {
								case 0:
										BulletAttack(CD);
										break;
				case 1:
					BomAttack(CD);
					break;
								}
								break;
						case CardData.TYPE.ITEM:
								switch (CD.id) {
								case 0:
										break;
								}
								break;
						}
				}
		}

	private bool BulletAttack ( CardData CD ) {
		pPlayer.rigor = CD.rigor;
		pPlayer.animator.SetInteger("State", 4);

		GameObject Area = GameObject.Find("Area" + pPlayer.AreaIdx);
		//エフェクト
		Vector3 pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
		effectManager EM = GameManager.Instance.getEffectInstance();
		EM.provisionEffect(pos,CD.effect,CD.rigor);

		return true;
	}

	private bool BomAttack ( CardData CD ) {
		pPlayer.rigor = CD.rigor;
		pPlayer.animator.SetInteger("State", 4);
		
		GameObject Area = GameObject.Find("Area" + pPlayer.AreaIdx);
		//エフェクト
		Vector3 pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
		effectManager EM = GameManager.Instance.getEffectInstance();
		EM.provisionEffect(pos,CD.effect,CD.rigor);
		
		return true;
	}
	
	public bool sordRange (CardData CD) {
		pPlayer.animator.SetInteger("State", 4);
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
		int Range = pPlayer.AreaIdx + 3;

        GameObject Area = GameObject.Find("Area" + Range);
        //エフェクト
        Vector3 pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
		effectManager EM = GameManager.Instance.getEffectInstance();
		EM.provisionEffect(pos,CD.effect,CD.rigor);

		foreach(GameObject obj in objs) {
			if( EnemyHit(Range,obj) ) {
				return true;
			}
		}
		return false;
	}

	public bool wideSordRange (CardData CD) {
		pPlayer.animator.SetInteger("State", 4);
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
		int[] Range = {pPlayer.AreaIdx + 3,pPlayer.AreaIdx + 4,pPlayer.AreaIdx + 2};

		if (Range [0] <= 18) {
			foreach (GameObject obj in objs) {
					EnemyHit (Range [0], obj);
					effectManager EM = GameManager.Instance.getEffectInstance();
					GameObject Area = GameObject.Find ("Area" + Range [0]);
					Vector3 pos = new Vector3 (Area.transform.position.x, Area.transform.position.y + 1.0f, Area.transform.position.z);
					EM.provisionEffect(pos,CD.effect,CD.rigor);
					if ((pPlayer.AreaIdx - 1) % 3 != 2) {
							EnemyHit (Range [1], obj);
							Area = GameObject.Find ("Area" + Range [1]);
						 	pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
							EM.provisionEffect(pos,CD.effect,CD.rigor);
					}
					if ((pPlayer.AreaIdx - 1) % 3 != 0) {
							EnemyHit (Range [2], obj);
							Area = GameObject.Find ("Area" + Range [2]);
							pos = new Vector3 (Area.transform.position.x, Area.transform.position.y + 1.0f, Area.transform.position.z);
							EM.provisionEffect(pos,CD.effect,CD.rigor);
					}
			}
		}
		return false;
	}

	public bool longSordRange (CardData CD) {
		pPlayer.animator.SetInteger("State", 4);
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
		int[] Range = {pPlayer.AreaIdx + 3,pPlayer.AreaIdx + 6};

		if( Range[0] <= 18 ) {
			foreach(GameObject obj in objs) {
				EnemyHit(Range[0],obj);
				effectManager EM = GameManager.Instance.getEffectInstance();
				GameObject Area = GameObject.Find("Area" + Range[0]);
				Vector3 pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
				EM.provisionEffect(pos,CD.effect,CD.rigor);

				if( Range[1] <= 18 ) {
				EnemyHit(Range[1],obj);
				Area = GameObject.Find("Area" + Range[1]);
				pos = new Vector3(Area.transform.position.x,Area.transform.position.y+1.0f,Area.transform.position.z);
				EM.provisionEffect(pos,CD.effect,CD.rigor);
				}
			}
		}
		return false;
	}

	private bool EnemyHit (int nRange,GameObject obj) {
		enemy pEnemy = obj.GetComponent<enemy>();
		if ( nRange == pEnemy.AreaIdx ) {
			pEnemy.nHp -= 1;
			if ( pEnemy.nHp <= 0 ) {
				Object.Destroy(obj);
			}
			return true;
		}
		return false;
	}
}
