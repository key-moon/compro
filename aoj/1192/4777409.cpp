// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1192/judge/4777409/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;


int main() {
	while (true)
	{
		int x, y, s;
		cin >> x >> y >> s;
		if (x == 0) break;
		x += 100;
		y += 100;
		int res = 0;
		for (int i = 1; i < s; i++)
		{
			for (int j = 1; j < s; j++)
			{
				if (i * x / 100 + j * x / 100 == s) {
					res = max(res, i * y / 100 + j * y / 100);
				}
			}
		}
		cout << res << endl;
	}
}

