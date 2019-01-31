using UnityEngine;

public class enemyGenerateScript : MonoBehaviour
{

    public Transform enemyPrefab;
    private double i = 0;
    private double j = 0;


    void Update()
    {
        i = Time.realtimeSinceStartup;

        if ((i - j) > 1) //increasing # will cause less enemies to appear
        {
            var enemyTransform = Instantiate(enemyPrefab) as Transform;

            enemyTransform.position = new Vector3(10, Random.Range(-4, 4), -2);
            j = i;
        }

    }

}