// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2197/judge/4777433/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;


int main() {
	while (true)
	{
		int n;
		cin >> n;
		if (n == 0) break;
		int res = 0;
		for (size_t i = 1; i < n; i++)
		{
			int sum = 0;
			for (size_t j = i; sum < n; j++) sum += j;
			if (sum == n) res++;
		}
		cout << res << endl;
	}
}


