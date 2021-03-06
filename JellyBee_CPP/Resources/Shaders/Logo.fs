precision mediump float;
uniform float u_time;
uniform sampler2D u_texture;
uniform sampler2D u_texture1;
uniform sampler2D u_texture2;
varying vec2 v_uv;

void main()
{
	float dMax = 0.04;
	vec2 disp;
	
	if (u_time < 3.0)
	{
		disp = vec2(texture2D(u_texture1, vec2(v_uv.x + u_time / 3.0 , 0.5)).g, 0.5);
	}
	else
	{
		disp = vec2(0.5, 0.5);
	}
	
	vec2 offset = (2.0 * disp - 1.0) * dMax;
	vec2 uvDisplaced = v_uv + offset;
	vec4 fire_color = texture2D(u_texture, uvDisplaced);
	vec4 AlphaValue = texture2D(u_texture2, v_uv);
	gl_FragColor = fire_color * vec4(1.0, 1.0, 1.0, AlphaValue.r);
    if (gl_FragColor.a < 0.25) 
        discard;
//    gl_FragColor = texture2D(u_texture, v_uv) * texture2D(u_texture1, v_uv)  * texture2D(u_texture2, v_uv) ;
}
