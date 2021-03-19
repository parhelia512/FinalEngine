#version 460

layout (location = 0) in vec4 in_color;
layout (location = 1) in vec2 in_texCoord;

out vec4 out_color;

struct Material
{
    sampler2D diffuseMap;
};

uniform Material u_material;

void main()
{
    out_color = texture(u_material.diffuseMap, in_texCoord) * in_color;
}