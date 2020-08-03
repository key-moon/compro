// detail: https://codeforces.com/contest/788/submission/88798713
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

bool hasCoke[1001];

int gcd(int a, int b) {
	return a == 0 ? b : gcd(b % a, a);
}

template<int len>
int solve(vector<int> shifts) {
	reverse(shifts.begin(), shifts.end());
	vector<bitset<len>> dp(shifts.size(), bitset<len>{1});
	for (size_t attempt = 0; attempt <= 1000; attempt++)
	{
		for (size_t i = 1; i < dp.size(); i++)
		{
			dp[i] |= dp[i - 1];
		}
		for (size_t i = 0; i < dp.size(); i++)
		{
			if (shifts[i] <= 0) {
				dp[i] >>= -shifts[i];
			}
			else {
				dp[i] <<= shifts[i];
			}
			if (dp[i][0]) {
				return attempt + 1;
			}
		}
	}
	return -1;
}

int main() {
	int n, k;
	cin >> n >> k;
	bool existBelow = false;
	bool existUpper = false;
	for (size_t i = 0; i < k; i++)
	{
		int a;
		cin >> a;
		hasCoke[a] = true;
	}
	vector<int> shifts{};
	for (size_t i = 0; i <= 1000; i++)
	{
		if (!hasCoke[i]) continue;
		shifts.push_back(i - n);
		if (i <= n) {
			existBelow = true;
		}
		if (n <= i) {
			existUpper = true;
		}
	}
	if (!existBelow || !existUpper) {
		cout << -1 << endl;
		return 0;
	}
	
	//合計が0
	//dp[何個目まで使った]→bitset
	//次は上からがーってマージしてからのshift
	var mx = 500 * 500;
	for (size_t i = 0; i < shifts.size(); i++)
	{
		if (0 < shifts[i]) continue;
		for (size_t j = 0; j < shifts.size(); j++)
		{
			if (shifts[j] < 0) continue;
			var a = shifts[j];
			var b = -shifts[i];
			var g = max(gcd(b, a), 1);
			var val = b / g * a;
			mx = min(mx, val);
		}
	}

	var res = -1;
	if (240000 <= mx) res = solve<250000>(shifts);
	else if (230000 <= mx) res = solve<240000>(shifts);
	else if (220000 <= mx) res = solve<230000>(shifts);
	else if (210000 <= mx) res = solve<220000>(shifts);
	else if (200000 <= mx) res = solve<210000>(shifts);
	else if (180000 <= mx) res = solve<200000>(shifts);
	else if (160000 <= mx) res = solve<180000>(shifts);
	else if (140000 <= mx) res = solve<160000>(shifts);
	else if (120000 <= mx) res = solve<140000>(shifts);
	else if (100000 <= mx) res = solve<120000>(shifts);
	else if (50000 <= mx) res = solve<100000>(shifts);
	else res = solve<50000>(shifts);

	cout << res << endl;
}
