// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2609/judge/4907980/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

ll dist(ll y1, ll x1, ll y2, ll x2) {
	var dy = abs(y1 - y2);
	var dx = abs(x1 - x2);
	return dy * dy + dx * dx;
}

ll mirrorpos(ll target, ll blocksize, ll blockind) {
	var parity = abs(blockind) % 2;
	var targetPos = blocksize * blockind + 
		(parity == 0 ? target : (blocksize - target));
	return targetPos;
}

signed main() {
	ll w, h, v, t, x, y, p, q;
	cin >> w >> h >> v >> t >> x >> y >> p >> q;

	var radius = v * t;
	var radius2 = radius * radius;

	if (radius2 < dist(x, y, p, q)) {
		cout << 0 << endl;
		return 0;
	}

	ll res = 0;
	var xblock = radius / w + 2;
	var yblock = radius / h + 2;
	for (int xind = -xblock; xind <= xblock; xind++)
	{
		var xpos = mirrorpos(p, w, xind);
		if (radius2 < dist(x, y, xpos, q)) continue;
		ll pvalid = 0, pinvalid = yblock;
		while (pinvalid - pvalid > 1)
		{
			var mid = (pinvalid + pvalid) / 2;
			var ypos = mirrorpos(q, h, mid);
			if (dist(x, y, xpos, ypos) <= radius2) pvalid = mid;
			else pinvalid = mid;
		}
		ll nvalid = 0, ninvalid = -yblock;
		while (nvalid - ninvalid > 1)
		{
			var mid = (ninvalid + nvalid) / 2;
			var ypos = mirrorpos(q, h, mid);
			if (dist(x, y, xpos, ypos) <= radius2) nvalid = mid;
			else ninvalid = mid;
		}
		res += (pvalid - nvalid + 1);
	}
	cout << res << endl;
}


