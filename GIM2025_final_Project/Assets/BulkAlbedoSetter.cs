using UnityEngine;

public class BulkTerrainSetter : MonoBehaviour
{
    [Header("? Terrain ���� ����")]
    public Terrain targetTerrain;
    public Texture2D terrainAlbedo;

    private TerrainLayer[] originalLayers; // ���� ���� �����

    [ContextMenu("? Terrain �˺��� ����")]
    public void ApplyAlbedoToTerrain()
    {
        if (targetTerrain == null || terrainAlbedo == null)
        {
            Debug.LogWarning("?? Terrain �Ǵ� Terrain �ؽ�ó�� ��� �ֽ��ϴ�.");
            return;
        }

        // ���� ���̾� ����
        originalLayers = targetTerrain.terrainData.terrainLayers;

        // �� TerrainLayer ����
        TerrainLayer terrainLayer = new TerrainLayer();
        terrainLayer.diffuseTexture = terrainAlbedo;
        terrainLayer.tileSize = new Vector2(10, 10);

        // Terrain�� ����
        targetTerrain.terrainData.terrainLayers = new TerrainLayer[] { terrainLayer };

        Debug.Log("? Terrain�� ���ο� �ؽ�ó�� ����Ǿ����ϴ�.");
    }

    void OnApplicationQuit()
    {
        RestoreOriginalLayers();
    }

    void OnDisable()
    {
        // �����Ϳ��� �÷��� ��� ���� �ÿ��� �����ϵ���
        RestoreOriginalLayers();
    }

    private void RestoreOriginalLayers()
    {
        if (targetTerrain != null && originalLayers != null)
        {
            targetTerrain.terrainData.terrainLayers = originalLayers;
            Debug.Log("? Terrain �ؽ�ó�� ������� �����Ǿ����ϴ�.");
        }
    }
}
