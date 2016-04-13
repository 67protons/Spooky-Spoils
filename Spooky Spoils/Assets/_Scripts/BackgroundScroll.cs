using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    public GameObject background2, background3;
    public GameObject entryWall;
    private Player _player;
    private Blackbourne _blackBourne;
    private bool _enterFromFoyer = true;

	void Start () {
        this._player = FindObjectOfType<Player>();
        this._blackBourne = FindObjectOfType<Blackbourne>();
	}
	
	// Update is called once per frame
	void Update () {
        if  (this.background3.transform.position.y < this._player.transform.position.y)
        {
            this.background2.transform.position = new Vector3(this.background3.transform.position.x, this.background3.transform.position.y + this.background3.GetComponent<MeshRenderer>().bounds.size.y, this.background3.transform.position.z);
            this._blackBourne.transform.position = new Vector3(this.background3.transform.position.x, this.background3.transform.position.y + this.background3.GetComponent<MeshRenderer>().bounds.size.y/2, this.background3.transform.position.z);
        }

        if (this.background2.transform.position.y < this._player.transform.position.y)
        {
            this._enterFromFoyer = false;
            entryWall.SetActive(false);
            this.background3.transform.position = new Vector3(this.background2.transform.position.x, this.background2.transform.position.y + this.background2.GetComponent<MeshRenderer>().bounds.size.y, this.background2.transform.position.z);
            this._blackBourne.transform.position = new Vector3(this.background2.transform.position.x, this.background2.transform.position.y + this.background2.GetComponent<MeshRenderer>().bounds.size.y/2, this.background2.transform.position.z);
        }

        if (!this._enterFromFoyer && (this.background3.transform.position.y > this._player.transform.position.y))
        {
            this.background2.transform.position = new Vector3(this.background3.transform.position.x, this.background3.transform.position.y - this.background3.GetComponent<MeshRenderer>().bounds.size.y, this.background3.transform.position.z);
            this._blackBourne.transform.position = new Vector3(this.background3.transform.position.x, this.background3.transform.position.y - this.background3.GetComponent<MeshRenderer>().bounds.size.y/2, this.background3.transform.position.z);
        }

        if (!this._enterFromFoyer && (this.background2.transform.position.y > this._player.transform.position.y))
        {
            this.background3.transform.position = new Vector3(this.background2.transform.position.x, this.background2.transform.position.y - this.background2.GetComponent<MeshRenderer>().bounds.size.y, this.background2.transform.position.z);
            this._blackBourne.transform.position = new Vector3(this.background2.transform.position.x, this.background2.transform.position.y - this.background2.GetComponent<MeshRenderer>().bounds.size.y/2, this.background2.transform.position.z);
        }
	}
}
