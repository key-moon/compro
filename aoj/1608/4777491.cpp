// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1608/judge/4777491/C++14
#include <bits/stdc++.h>

#define var auto
#define in :
#define ll long long

using namespace std;


int main() {
	while (true)
	{
		int n;
		cin >> n;
		if (n == 0) break;
		vector<int> a(n);
		for (int i = 0; i < n; i++) cin >> a[i];
		sort(a.begin(), a.end());
		for (int i = 0; i < n - 1; i++) a[i] = a[i + 1] - a[i];
		a[n - 1] = INT32_MAX;
		cout << *min_element(a.begin(), a.end()) << endl;
	}
}


