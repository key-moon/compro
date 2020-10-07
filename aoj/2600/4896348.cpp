// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2600/judge/4896348/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

int main() {
	int n, W, H;
	cin >> n >> W >> H;
	vector<int> ws(W, 0);
	vector<int> hs(H, 0);
	for (size_t i = 0; i < n; i++)
	{
		int x, y, w;
		cin >> x >> y >> w;
		var fill = [](vector<int>& vec, int p, int w) {
			var start = p - w;
			var end = p + w;
			if (start < 0) start = 0;
			vec[start]++;
			if (vec.size() <= end) return;
			vec[end]--;
		};
		fill(ws, x, w);
		fill(hs, y, w);
	}

	var judge = [](vector<int>& a) {
		int cur = 0;
		for (size_t i = 0; i < a.size(); i++)
		{
			cur += a[i];
			if (cur == 0) return false;
		}
		return true;
	};

	cout << (judge(ws) || judge(hs) ? "Yes" : "No") << endl;
}


