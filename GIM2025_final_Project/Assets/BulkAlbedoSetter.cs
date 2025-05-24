using UnityEngine;

public class BulkTerrainSetter : MonoBehaviour
{
    [Header("? Terrain 관련 설정")]
    public Terrain targetTerrain;
    public Texture2D terrainAlbedo;

    private TerrainLayer[] originalLayers; // 원래 상태 저장용

    [ContextMenu("? Terrain 알베도 적용")]
    public void ApplyAlbedoToTerrain()
    {
        if (targetTerrain == null || terrainAlbedo == null)
        {
            Debug.LogWarning("?? Terrain 또는 Terrain 텍스처가 비어 있습니다.");
            return;
        }

        // 원래 레이어 저장
        originalLayers = targetTerrain.terrainData.terrainLayers;

        // 새 TerrainLayer 생성
        TerrainLayer terrainLayer = new TerrainLayer();
        terrainLayer.diffuseTexture = terrainAlbedo;
        terrainLayer.tileSize = new Vector2(10, 10);

        // Terrain에 적용
        targetTerrain.terrainData.terrainLayers = new TerrainLayer[] { terrainLayer };

        Debug.Log("? Terrain에 새로운 텍스처가 적용되었습니다.");
    }

    void OnApplicationQuit()
    {
        RestoreOriginalLayers();
    }

    void OnDisable()
    {
        // 에디터에서 플레이 모드 종료 시에도 동작하도록
        RestoreOriginalLayers();
    }

    private void RestoreOriginalLayers()
    {
        if (targetTerrain != null && originalLayers != null)
        {
            targetTerrain.terrainData.terrainLayers = originalLayers;
            Debug.Log("? Terrain 텍스처가 원래대로 복원되었습니다.");
        }
    }
}
