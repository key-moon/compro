// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2303/judge/4907982/C++14
#include <bits/stdc++.h>

using ll = long long;
const char newl = '\n';
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

signed main() {
	ll n, m, l;
	cin >> n >> m >> l;
	vector<ll> p(n);
	vector<ll> t(n);
	vector<ll> v(n);


	vector<vector<double>> restprobs(n, vector<double>(m + 1));
	for (int i = 0; i < n; i++)
	{
		cin >> p[i] >> t[i] >> v[i];	
		var prob = p[i] / 100.0;
		var& probs = restprobs[i];
		probs[0] = 1;
		for (int j = 0; j < m; j++)
		{
			for (int i = m - 1; i >= 0; i--)
			{
				var curprob = probs[i];
				var next = curprob * prob;
				var cur = curprob * (1 - prob);

				probs[i + 1] += next;
				probs[i] = cur;
			}
		}
	}

	if (m == 0) {
		int fastestind = 0;
		int fastest = 0;
		for (size_t i = 0; i < n; i++)
		{
			if (fastest < v[i]) fastestind = i, fastest = v[i];
			else if (fastest == v[i]) {
				fastestind = -1;
				fastest = INT32_MAX;
			}
		}
		for (size_t i = 0; i < n; i++)
		{
			if (i == fastestind) cout << 1 << endl;
			else cout << 0 << endl;
		}
		return 0;
	}

	for (size_t my = 0; my < n; my++)
	{
		double res = 0;
		for (size_t myrest = 0; myrest <= m; myrest++)
		{
			double winprob = 1;
			for (size_t opp = 0; opp < n; opp++)
			{
				double internalwinprob = 0;
				if (v[my] == 0 && v[opp] == 0) {
					winprob = 0;
					continue;
				}
				else if (v[my] == 0) {
					winprob = 0;
					continue;
				}
				else if (v[opp] == 0) {
					continue;
				}
				if (my == opp) continue;
				ll muler = v[my] * v[opp];
				ll mygoalt = l * muler / v[my];
				ll oppgoalt = l * muler / v[opp];

				ll myrestt = t[my] * muler;
				ll opprestt = t[opp] * muler;
				
				for (size_t opprest = 0; opprest <= m; opprest++)
				{
					ll mytotalt = mygoalt + myrestt * myrest;
					ll opptotalt = oppgoalt + opprestt * opprest;
					if (mytotalt < opptotalt) {
						internalwinprob += restprobs[opp][opprest];
					}
				}
				winprob *= internalwinprob;
			}
			res += winprob * restprobs[my][myrest];
		}

		cout << fixed << setprecision(15);
		cout << res << endl;
	}
}


