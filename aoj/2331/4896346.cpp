// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2331/judge/4896346/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

int main() {
	int n;
	cin >> n;
	vector<int> imos(100010);
	for (size_t i = 0; i < n; i++)
	{
		int a, b;
		cin >> a >> b;
		imos[a]++;
		imos[b + 1]--;
	}
	int cur = 0;
	int res = 0;
	for (size_t i = 1; i <= n + 1; i++)
	{
		//i人で行ける
		cur += imos[i];
		if (i - 1 <= cur) res = i - 1;
		//cout << i << " " << cur << endl;
	}
	cout << res << endl;
}


