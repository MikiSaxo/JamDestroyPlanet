void DistancePos_half(in float3 playerPos, in float3 worldPos, in float radius, in float3 primaryTexture, in float3 secondaryTexture,in float4 ColorFresnel, in float fresnelThickness, out float3 Out)
{
	if(distance(playerPos.xyz, worldPos.xyz) > radius)
	{
		Out = primaryTexture;
	}
	else if (distance(playerPos.xyz, worldPos.xyz) > radius - fresnelThickness)
	{
		Out = ColorFresnel;
	}
	else
	{
		Out = secondaryTexture;
	}



}