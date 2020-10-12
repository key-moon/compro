// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2237/judge/4907983/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	int m, n;
	cin >> m >> n;
	vector<vector<double>> probs(m, vector<double>(n));
	for (size_t i = 0; i < m; i++)
	{
		for (size_t j = 0; j < n; j++)
		{
			cin >> probs[i][j];
		}
	}
	vector<vector<double>> dp(n + 1, vector<double>(1 << m));
	for (size_t i = 0; i < (1 << m); i++) dp[n][i] = 1;
	dp[n][(1 << m) - 1] = 0;

	for (int i = n - 1; i >= 0; i--)
	{
		for (int j = (1 << m) - 1; j >= 0; j--)
		{
			double maxprob = 0.0;
			for (int nxt = 0; nxt < m; nxt++)
			{
				if (j >> nxt & 1) continue;
				
				var totalprob = 0.0;

				var winprob = 1.0;
				for (int room = i; room < n; room++)
				{
					var loseProb = winprob * (1 - probs[nxt][room]);
					winprob *= probs[nxt][room];
					totalprob += dp[room][j | (1 << nxt)] * loseProb;
				}

				totalprob += winprob;

				chmax(maxprob, totalprob);
			}
			dp[i][j] = maxprob;
		}
	}
	cout << fixed << setprecision(15);
	cout << dp[0][0] << endl;
}


