using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	private enum Mode { simple, adaptive }
	[SerializeField] private Mode mode;
	[SerializeField] private float radius;
	[SerializeField] private float power;
	[SerializeField] private LayerMask layerMask;
	public GameObject visual;

	public float timeToExplode;
    public bool Active = false;

    private float timer = 0;
    private void FixedUpdate()
    {
        if (Active)
        {
            timer += Time.fixedDeltaTime;
        }
        if(timer >= timeToExplode)
        {
			Instantiate(visual, transform.position, Quaternion.identity);
			Explosion2D(transform.position);
			GameManager.instance.DeleteEntity(gameObject);
		}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
		Active = true;
	}

	void Explosion2D(Vector3 position)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);

		foreach (Collider2D hit in colliders)
		{
			if (hit.attachedRigidbody != null)
			{
				Vector3 direction = hit.transform.position - position;
				direction.z = 0;

				if (CanUse(position, hit.attachedRigidbody))
				{
					hit.attachedRigidbody.AddForce(direction.normalized * power);

					//Debug.Log(hit.transform.name);
				}
			}
		}
	}

	bool CanUse(Vector3 position, Rigidbody2D body)
	{
		if (mode == Mode.simple) return true;

		RaycastHit2D hit = Physics2D.Linecast(position, body.position);

		if (hit.rigidbody != null && hit.rigidbody == body)
		{
			return true;
		}

		return false;
	}
}
