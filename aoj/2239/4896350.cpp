// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2239/judge/4896350/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

int main() {
	ll n, m, a, b, p, q;
	cin >> n >> m >> a >> b >> p >> q;
	if (a == 1 && b == 1) {
		var ticket = p + q;
		var t1 = m / ticket;
		var t2 = m / ticket + 1;
		t1 = min(t1, n);
		t2 = min(t2, n);
		var res = min(abs(m - t1 * ticket), abs(m - t2 * ticket));
		cout << res << endl;
		return 0;
	}
	
	const var OF_MAX = (LLONG_MAX / 2);
	vector<ll> moves{};
	ll aPow = 1;
	ll bPow = 1;
	for (size_t i = 0; i < n; i++)
	{
		if (OF_MAX / p <= aPow || OF_MAX / q <= bPow) break;

		var ticket = p * aPow + q * bPow;
		if (1e15 < ticket) break;
		moves.push_back(ticket);
		if (m < ticket) break;

		if (OF_MAX / a <= aPow || OF_MAX / b <= bPow) break;
		aPow *= a;
		bPow *= b;
	}

	var make = [](vector<ll>& v) {
		vector<ll> res{};
		var n = v.size();
		for (int i = 0; i < (1 << n); i++)
		{
			ll sum = 0;
			for (int j = 0; j < n; j++)
			{
				if (i >> j & 1) {
					sum += v[j];
				}
			}
			res.push_back(sum);
		}
		return res;
	};

	if (moves.size() <= 20) {
		var arr = make(moves);
		ll res = m;
		for (var&& item : arr) {
			res = min(res, abs(item - m));
		}
		cout << res << endl;
		return 0;
	}

	int threshold = moves.size() / 2;
	vector<ll> move1{};
	vector<ll> move2{};
	for (size_t i = 0; i < threshold; i++)
		move1.push_back(moves[i]);
	
	for (size_t i = threshold; i < moves.size(); i++)
		move2.push_back(moves[i]);
	
	var v1 = make(move1);
	var v2 = make(move2);

	ll res = m;

	sort(v2.begin(), v2.end());
	v2.push_back((ll)1e15);
	for (var&& item : v1) {
		if (m < item) {
			res = min(res, abs(item - m));
			continue;
		}
		int valid = 0;
		int invalid = v2.size() - 1;
		while (invalid - valid > 1)
		{
			var mid = (invalid + valid) / 2;
			if (item + v2[mid] <= m) valid = mid;
			else invalid = mid;
		}
		res = min(res, abs(item + v2[valid] - m));
		res = min(res, abs(item + v2[valid + 1] - m));
	}
	cout << res << endl;
}


