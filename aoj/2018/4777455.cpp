// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2018/judge/4777455/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;


int main() {
	while (true)
	{
		int n, m, p;
		cin >> n >> m >> p;
		if (n == 0) break;
		int win = 0;
		int total = 0;
		for (int i = 1; i <= n; i++)
		{
			int a;
			cin >> a;
			total += a;
			if (i == m) win = a;
		}
		cout << (win == 0 ? 0 : total * (100 - p) / win) << endl;
	}
}


