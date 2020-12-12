#version 460

layout (location = 0) in vec4 in_color;
layout (location = 1) in vec2 in_texCoord;

out vec4 out_color;

uniform sampler2D u_texture;
uniform vec4 u_color;

void main()
{
	out_color = u_color;
}