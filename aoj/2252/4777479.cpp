// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2252/judge/4777479/C++14
#include <bits/stdc++.h>

#define var auto
#define in :
#define ll long long

using namespace std;


int main() {
	string a = "qwertasdfgzxcvb";
	while (true)
	{
		string s;
		cin >> s;
		if (s == "#") break;
		bool last = a.find(s[0]) != string::npos;
		int res = 0;
		for (var&& c in s) {
			var contains = a.find(c) != string::npos;
			if (last ^ contains)res++;
			last = contains;
		}
		cout << res << endl;
	}
}


